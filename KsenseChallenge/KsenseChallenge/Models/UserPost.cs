﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KsenseChallenge.Models
{
    public class UserPost
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}