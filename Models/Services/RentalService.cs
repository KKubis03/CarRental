using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;

namespace CarRental.Models.Services
{
    public class RentalService : BaseService<RentalDto, Rental>
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public override void AddModel(Rental model)
        {
            DatabaseContext.Add(model);
            if(IsValid(model))
                DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(RentalDto model)
        {
            Rental rental = DatabaseContext.Rentals.First(item => item.Id == model.Id);
            rental.IsActive = false;
            rental.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Rental GetModel(int id)
        {
            return DatabaseContext.Rentals.First(item => item.Id == id);
        }

        public override List<RentalDto> GetModels()
        {
            IQueryable<Rental> rentals = DatabaseContext.Rentals
                .Where(item => item.IsActive);
            if(MinPrice != 0)
            {
                rentals = rentals.Where(item => item.BaseAmount >= MinPrice);
            }
            if (MaxPrice != 0)
            {
                rentals = rentals.Where(item => item.BaseAmount <= MaxPrice);
            }
            if (!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": rentals = !Descending ? rentals.OrderBy(item => item.Id) : rentals.OrderByDescending(item => item.Id); break;
                    case "Car": rentals = !Descending ? rentals.OrderBy(item => item.Car.Brand.CarBrandName) : rentals.OrderByDescending(item => item.Car.Brand.CarBrandName); break;
                    case "Customer": rentals = !Descending ? rentals.OrderBy(item => item.Customer.FirstName) : rentals.OrderByDescending(item => item.Customer.FirstName); break;
                    case "Price": rentals = !Descending ? rentals.OrderBy(item => item.BaseAmount) : rentals.OrderByDescending(item => item.BaseAmount); break;

                }
            }
            IQueryable<RentalDto> rentalsDto = rentals.Select(item => new RentalDto()
            {
                Id = item.Id,
                Car = item.Car.Brand.CarBrandName +" " + item.Car.Model.CarModelName,
                Customer = item.Customer.FirstName + " " + item.Customer.LastName,
                Price = item.BaseAmount.ToString()
            });
            return rentalsDto.ToList();
        }

        public override void UpdateModel(Rental model)
        {
            DatabaseContext.Rentals.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Rental CreateModel()
        {
            return new Rental()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }

        public override bool IsValid(Rental model)
        {
            if (model.CustomerId != 0 && model.CarId != 0 && model.BaseAmount >= 0)
                return true;
            else return false;
        }
    }
}
