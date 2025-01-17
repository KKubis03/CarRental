using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string Rating { get; set; } = null!;
        public string Rental { get; set; } = null!;
    }
}
