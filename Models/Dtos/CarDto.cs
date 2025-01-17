using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Category { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Status   { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Vin {  get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
        public string GearboxType { get; set; } = null!;
        public string FuelType  { get; set; } = null!;
        public string Color { get; set; } = null!;
    }
}
