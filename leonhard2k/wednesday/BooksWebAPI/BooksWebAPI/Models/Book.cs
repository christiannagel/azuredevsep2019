﻿using System;
using System.Collections.Generic;

namespace BooksWebAPI
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }
    }
}
