using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public string BasePrice { get; set; } = null!;
        public string FinalPrice { get; set; }= null!;
        public string Discount { get; set; } = null!;
        public string Rental { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
