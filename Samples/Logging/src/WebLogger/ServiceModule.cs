﻿using System;
using Nancy;

namespace FP.DevSpace2016.Logging.WebLogger
{
    public class ServiceModule : NancyModule
    {
        public ServiceModule(LoggingRepository loggingRepository)
        {
            Get("/Service/{sessionId}", async (parameter, ct) =>
            {
                Guid sessionId;
                var timestamp = DateTime.UtcNow;
                var remoteHost = Context.Request.UserHostAddress;

                if (!Guid.TryParse(parameter.sessionId, out sessionId))
                {
                    await loggingRepository.SendErrorLog(remoteHost, timestamp, Environment.MachineName);
                    return HttpStatusCode.BadRequest;
                }

                await loggingRepository.SendLog(sessionId, remoteHost, timestamp, Environment.MachineName);

                return Response.AsJson(new { Session = sessionId, Timestamp = timestamp, Hostname = Environment.MachineName });
            });
        }
    }
}
