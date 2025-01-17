using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Dtos
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Percentage { get; set; } = null!;
    }
}
