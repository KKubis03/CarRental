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
    }
}
