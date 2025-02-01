using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Dtos;

namespace CarRental.Models.Services
{
    public class ReservationService : BaseService<ReservationDto, Reservation>
    {
        public string Customer {  get; set; }
        public string Car {  get; set; }
        public int StatusId { get; set; }
        public override void AddModel(Reservation model)
        {
            DatabaseContext.Reservations.Add(model);
            if(IsValid(model))
                DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ReservationDto model)
        {
            Reservation reservation = DatabaseContext.Reservations.First(item => item.Id == model.Id);
            reservation.IsActive = false;
            reservation.DeleteDateTime = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Reservation GetModel(int id)
        {
            return DatabaseContext.Reservations.First(item => item.Id == id);
        }

        public override List<ReservationDto> GetModels()
        {
            IQueryable<Reservation> reservations = DatabaseContext.Reservations.Where(item => item.IsActive);
            if(!string.IsNullOrEmpty(Customer))
            {
                reservations = reservations.Where(item => item.Customer.FirstName.Contains(Customer) || item.Customer.LastName.Contains(Customer));
            }
            if (!string.IsNullOrEmpty(Car))
            {
                reservations = reservations.Where(item => item.Car.Brand.CarBrandName.Contains(Car) || item.Car.Model.CarModelName.Contains(Car));
            }
            if(StatusId != 0)
            {
                reservations = reservations.Where(item => item.StatusId == StatusId);
            }
            if (!string.IsNullOrEmpty(ColumnName))
            {
                switch (ColumnName)
                {
                    case "Id": reservations = !Descending ? reservations.OrderBy(item => item.Id) : reservations.OrderByDescending(item => item.Id); break;
                    case "Car": reservations = !Descending ? reservations.OrderBy(item => item.Car.Brand.CarBrandName) : reservations.OrderByDescending(item => item.Car.Brand.CarBrandName); break;
                    case "Customer": reservations = !Descending ? reservations.OrderBy(item => item.Customer.FirstName) : reservations.OrderByDescending(item => item.Customer.FirstName); break;
                    case "Status": reservations = !Descending ? reservations.OrderBy(item => item.Status.StatusName) : reservations.OrderByDescending(item => item.Status.StatusName); break;
                }
            }
            IQueryable<ReservationDto> reservationDtos = reservations.Select(item => new ReservationDto
            {
                Id = item.Id,
                Customer = item.Customer.FirstName + " " + item.Customer.LastName,
                Car = item.Car.Brand.CarBrandName + " " + item.Car.Model.CarModelName,
                Status = item.Status.StatusName
            });
            return reservationDtos.ToList();
        }

        public override void UpdateModel(Reservation model)
        {
            DatabaseContext.Reservations.Update(model);
            DatabaseContext.SaveChanges();
        }
        public override Reservation CreateModel()
        {
            return new Reservation()
            {
                IsActive = true,
                CreationDateTime = DateTime.Now,
            };
        }

        public override bool IsValid(Reservation model)
        {
            if (model.CustomerId != 0 && model.CarId != 0 && model.StatusId != 0)
                return true;
            else return false;
        }
    }
}
