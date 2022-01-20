using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string Genre { get; set; }

        public bool IsDeleted { get; set; }
    }
}
