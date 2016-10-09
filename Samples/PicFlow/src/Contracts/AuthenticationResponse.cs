using System;

namespace FP.DevSpace2016.PicFlow.Contracts
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string User { get; set; }

        public bool IsValid { get; set; }
    }
}
