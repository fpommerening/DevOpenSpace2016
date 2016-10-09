using System;

namespace FP.DevSpace2016.PicFlow.Contracts
{
    public class AuthenticationRequest
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}
