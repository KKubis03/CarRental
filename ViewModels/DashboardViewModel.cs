using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Contexts;
using CarRental.Models.Services;
using Microsoft.Identity.Client;

namespace CarRental.ViewModels
{
    public class DashboardViewModel : WorkspaceViewModel
    {
        DatabaseContext db;
        public int NumberOfCustomers { get; set; }
        public int NumberOfRentals { get; set; }
        public int NumberOfReservations { get; set; }
        public int NumberOfCars { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue {  get; set; }

        public DashboardViewModel() : base("Dashboard")
        {
            db = new DatabaseContext();
            NumberOfCustomers = GetNumberOfCustomers();
            NumberOfRentals = GetNumberOfRentals();
            NumberOfReservations = GetNumberOfReservations();
            NumberOfCars = GetNumberOfCars();
            TotalRevenue = GetTotalRevenue();
            MonthlyRevenue = GetMonthlyRevenue();
        }
        private int GetNumberOfCustomers()
        {
            IQueryable<Customer> customers = db.Customers.Where(item => item.IsActive == true);
            return customers.Count();
        }
        private int GetNumberOfRentals()
        {
            IQueryable<Rental> rentals = db.Rentals.Where(item => item.IsActive == true);
            return rentals.Count();
        }
        private int GetNumberOfReservations()
        {
            IQueryable<Reservation> reservations = db.Reservations.Where(item => item.IsActive == true);
            return reservations.Count();
        }
        private int GetNumberOfCars()
        {
            IQueryable<Car> cars = db.Cars.Where(item => item.IsActive == true);
            return cars.Count();
        } 
        private decimal GetTotalRevenue()
        {
            decimal totalRevenue = 0;
            IQueryable<Payment> payments = db.Payments.Where(item => item.IsActive == true);
            foreach (Payment payment in payments)
            {
                totalRevenue += payment.FinalAmount;
            }
            return Math.Round(totalRevenue, 2);
        }
        private decimal GetMonthlyRevenue()
        {
            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            decimal MonthlyRevenue = 0;
            IQueryable<Payment> payments = db.Payments.Where(item => item.IsActive == true && item.PaymentDate >= startOfMonth && item.PaymentDate <= endOfMonth);
            foreach (Payment payment in payments)
            {
                MonthlyRevenue += payment.FinalAmount;
            }
            return Math.Round(MonthlyRevenue, 2);
        }
    }
}
