﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 2-24-21

namespace OnlineBookstore.Models
{
    public class Book
    {
        [Key]
        public int BookId {get; set;}
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"\d{3}-\d{10}", ErrorMessage = "Please format your ISBN number XXX-XXXXXXXXXX")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
