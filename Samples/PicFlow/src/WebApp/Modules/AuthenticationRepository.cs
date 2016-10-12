using System;
using System.Collections.Concurrent;
using EasyNetQ;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.Messages;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class AuthenticationRepository
    {
        private readonly ConcurrentDictionary<Guid, AuthUser> userSessions = new ConcurrentDictionary<Guid, AuthUser>();


        public AuthenticationRepository()
        {
            

        }

        public Task SendAuthorizationRequest(Guid sessionId, string userName, string passwordBase64)
        {
            var authRequest = new AuthenticationRequest
            {
                Id = sessionId,
                PasswordHash = passwordBase64,
                UserName = userName
            };
            return null;
        }

        public AuthUser GetAuthUserBySessionId(Guid sessionId)
        {
            if (!userSessions.ContainsKey(sessionId))
                return null;
            return userSessions[sessionId];
        }

        public void DeleteSession(Guid sessionId)
        {
            if (userSessions.ContainsKey(sessionId))
            {
                userSessions.Remove(sessionId);
            }
        }
    }
}
