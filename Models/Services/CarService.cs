using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models.Services
{
    public class CarService : BaseService<CarDto, Car>
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public bool IsAvailable { get; set; }
        public override void AddModel(Car model)
        {
            DatabaseContext.Cars.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(CarDto model)
        {
            Car car = DatabaseContext.Cars.First(item => item.Id == model.Id);
            car.IsActive = false;
            car.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Car GetModel(int id)
        {
            return DatabaseContext.Cars.First(item => item.Id == id);
        }

        public override List<CarDto> GetModels()
        {
            IQueryable<Car> cars = DatabaseContext.Cars.Include(item => item.Category)
                                                            .Include(item => item.Brand)
                                                            .Include(item => item.Model)
                                                            .Include(item => item.Status)
                                                            .Include(item => item.GearboxType)
                                                            .Include(item => item.FuelType)
                                                            .Include(item => item.Color)
                                                            .Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                cars = cars.Where(item => item.Brand.CarBrandName.Contains(SearchInput));
            }
            if(CategoryId != 0)
            {
                cars = cars.Where(item => item.CategoryId == CategoryId);
            }
            if(BrandId != 0)
            {
                cars = cars.Where(item => item.BrandId == BrandId);
            }
            if(IsAvailable)
            {
                cars = cars.Where(item => item.StatusId == 1);
            }
            if(!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": cars = !Descending ? cars.OrderBy(item => item.Id) : cars.OrderByDescending(item => item.Id); break;
                    case "Category": cars = !Descending ? cars.OrderBy(item => item.Category.CategoryName) : cars.OrderByDescending(item => item.Category.CategoryName); break;
                    case "Brand": cars = !Descending ? cars.OrderBy(item => item.Brand.CarBrandName) : cars.OrderByDescending(item => item.Brand.CarBrandName); break;
                    case "Model": cars = !Descending ? cars.OrderBy(item => item.Model.CarModelName) : cars.OrderByDescending(item => item.Model.CarModelName); break;
                    case "Status": cars = !Descending ? cars.OrderBy(item => item.Status.StatusName) : cars.OrderByDescending(item => item.Status.StatusName); break;
                    case "Year": cars = !Descending ? cars.OrderBy(item => item.ProductionYear) : cars.OrderByDescending(item => item.ProductionYear); break;
                    case "Vin": cars = !Descending ? cars.OrderBy(item => item.Vin) : cars.OrderByDescending(item => item.Vin); break;
                    case "LicensePlate": cars = !Descending ? cars.OrderBy(item => item.LicensePlate) : cars.OrderByDescending(item => item.LicensePlate); break;
                    case "Gearbox": cars = !Descending ? cars.OrderBy(item => item.GearboxType.GearboxName) : cars.OrderByDescending(item => item.GearboxType.GearboxName); break;
                    case "Fuel": cars = !Descending ? cars.OrderBy(item => item.FuelType.FuelName) : cars.OrderByDescending(item => item.FuelType.FuelName); break;
                    case "Color": cars = !Descending ? cars.OrderBy(item => item.Color.ColorName) : cars.OrderByDescending(item => item.Color.ColorName); break;
                }
            }

            IQueryable<CarDto> carsDto = cars.Select(item => new CarDto()
            {
                Id = item.Id,
                Category = item.Category.CategoryName,
                Brand = item.Brand.CarBrandName,
                Model = item.Model.CarModelName,
                Status = item.Status.StatusName,
                Year = item.ProductionYear,
                Vin = item.Vin,
                LicensePlate = item.LicensePlate,
                GearboxType = item.GearboxType.GearboxName,
                FuelType = item.FuelType.FuelName,
                Color = item.Color.ColorName,
            });
            return carsDto.ToList();
        }

        public override void UpdateModel(Car model)
        {
            DatabaseContext.Cars.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Car CreateModel()
        {
            return new Car()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }
    }
}
