﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoAPI.Application.Payload.Resquest.UserResquest
{
    public class Request_Register
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Fullname { get; set; }

    }
}
