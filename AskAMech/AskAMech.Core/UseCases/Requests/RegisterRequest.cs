﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.UseCases.Requests
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
