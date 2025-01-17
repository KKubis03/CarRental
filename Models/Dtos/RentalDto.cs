using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public string Car { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public string Price { get; set; } = null!;
    }
}
