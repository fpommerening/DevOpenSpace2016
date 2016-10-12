using System;
using System.Threading.Tasks;

namespace FP.DevSpace2016.Logging.WebLogger
{
    public class LoggingRepository
    {
        public Task SendErrorLog(string remoteHost, DateTime timestamp, string instanceHost)
        {
            return null;
        }

        public Task SendLog(Guid sessionId, string remoteHost, DateTime timestamp, string instanceHost)
        {
            return null;
        }
    }
}
