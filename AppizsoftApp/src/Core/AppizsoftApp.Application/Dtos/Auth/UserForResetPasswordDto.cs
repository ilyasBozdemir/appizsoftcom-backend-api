﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Auth
{
    public class UserForResetPasswordDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
