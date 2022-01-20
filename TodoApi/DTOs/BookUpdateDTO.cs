using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DTOs
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string Genre { get; set; }

    }
}
