using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;

namespace CarRental.ViewModels.Single
{
    public class CustomerInfoViewModel : WorkspaceViewModel
    {
        private DatabaseContext db;

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }
        private string _Surname;
        public string Surname
        {
            get => _Surname;
            set
            {
                if (_Surname != value)
                {
                    _Surname = value;
                    OnPropertyChanged(() => Surname);
                }
            }
        }
        private string _PhoneNumber;
        public string PhoneNumber
        {
            get => _PhoneNumber;
            set
            {
                if (_PhoneNumber != value)
                {
                    _PhoneNumber = value;
                    OnPropertyChanged(() => PhoneNumber);
                }
            }
        }
        private string _Email;
        public string Email
        {
            get => _Email;
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _Customers;
        public ObservableCollection<ComboBoxDto> Customers
        {
            get => _Customers;
            set
            {
                if (_Customers != value)
                {
                    _Customers = value;
                    OnPropertyChanged(() => Customers);
                }
            }
        }
        private int _CustomerId;
        public int CustomerId
        {
            get => _CustomerId;
            set
            {
                if (_CustomerId != value)
                {
                    _CustomerId = value;
                    OnPropertyChanged(() => CustomerId);
                    AssignData(CustomerId);
                }
            }
        }
        private int _Rentals;
        public int Rentals
        {
            get => _Rentals;
            set
            {
                if (_Rentals != value)
                {
                    _Rentals = value;
                    OnPropertyChanged(() => Rentals);
                }
            }
        }
        private int _Reservations;
        public int Reservations
        {
            get => _Reservations;
            set
            {
                if (_Reservations != value)
                {
                    _Reservations = value;
                    OnPropertyChanged(() => Reservations);
                }
            }
        }
        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get => _TotalAmount;
            set
            {
                if (_TotalAmount != value)
                {
                    _TotalAmount = value;
                    OnPropertyChanged(() => TotalAmount);
                }
            }
        }
        public CustomerInfoViewModel() : base("CustomerInfo")
        {
            db = new DatabaseContext();
            // Customers
            List<ComboBoxDto> customers = db.Customers.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.FirstName + " " + item.LastName
            }).ToList();
            _Customers = new ObservableCollection<ComboBoxDto>(customers);
        }
        private void AssignData(int CustomerId)
        {
            IQueryable<Customer> Customers = db.Customers.Where(item => item.IsActive);
            Customer customer = Customers.First(item => item.Id == CustomerId);
            Name = customer.FirstName;
            Surname = customer.LastName;
            PhoneNumber = customer.PhoneNumber;
            Email = customer.Email;
            IQueryable<Rental> rentals = db.Rentals.Where(item => item.IsActive && item.CustomerId == CustomerId);
            Rentals = rentals.Count();
            IQueryable<Reservation> reservations = db.Reservations.Where(item => item.IsActive && item.CustomerId == CustomerId);
            Reservations = reservations.Count();
            IQueryable<Payment> payments = db.Payments.Where(item => item.IsActive && item.Rental.CustomerId == CustomerId);
            decimal total = 0;
            foreach(Payment p in payments)
            {
                total += p.FinalAmount;
            }
            TotalAmount = Math.Round(total, 2); ;
        }
    }
}
