﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace http.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
