﻿using System;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class AuthUser
    {
        public AuthUser()
        {
            Id = Guid.Empty;
        }

        public Guid Id { get; set; }

        public string User { get; set; }

        public bool IsValid { get; set; }

        public bool IsEmpty()
        {
            return Id == Guid.Empty;
        }
    }
}