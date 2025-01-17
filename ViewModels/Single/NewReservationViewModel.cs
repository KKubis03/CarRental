using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;
using CarRental.Models.Services;

namespace CarRental.ViewModels.Single
{
    public class NewReservationViewModel : BaseCreateViewModel<ReservationService,ReservationDto,Reservation>
    {
        public NewReservationViewModel() : base("New Reservation")
        {
            // Statuses
            List<ComboBoxDto> statuses = Service.DatabaseContext.ReservationStatuses.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.StatusName
            }).ToList();
            _Statuses = new ObservableCollection<ComboBoxDto>(statuses);
            // Customers
            List<ComboBoxDto> customers = Service.DatabaseContext.Customers.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.FirstName + " " + item.LastName
            }).ToList();
            _Customers = new ObservableCollection<ComboBoxDto>(customers);
            // Cars
            List<ComboBoxDto> cars = Service.DatabaseContext.Cars.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.Brand.CarBrandName + " " + item.Model.CarModelName
            }).ToList();
            _Cars = new ObservableCollection<ComboBoxDto>(cars);
        }
        private ObservableCollection<ComboBoxDto> _Statuses;
        public ObservableCollection<ComboBoxDto> Statuses
        {
            get => _Statuses;
            set
            {
                if (_Statuses != value)
                {
                    _Statuses = value;
                    OnPropertyChanged(() => Statuses);
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
        private ObservableCollection<ComboBoxDto> _Cars;
        public ObservableCollection<ComboBoxDto> Cars
        {
            get => _Cars;
            set
            {
                if (_Cars != value)
                {
                    _Cars = value;
                    OnPropertyChanged(() => Cars);
                }
            }
        }
        public int CustomerId
        {
            get => Model.CustomerId;
            set
            {
                if (Model.CustomerId != value)
                {
                    Model.CustomerId = value;
                    OnPropertyChanged(() => CustomerId);
                }
            }
        }
        public int CarId
        {
            get => Model.CarId;
            set
            {
                if (Model.CarId != value)
                {
                    Model.CarId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
        }
        public int StatusId
        {
            get => Model.StatusId;
            set
            {
                if (Model.StatusId != value)
                {
                    Model.StatusId = value;
                    OnPropertyChanged(() => StatusId);
                }
            }
        }
        public override void ResetForm()
        {
            CustomerId = 0;
            OnPropertyChanged(() => CustomerId);
            CarId = 0;
            OnPropertyChanged(() => CarId);
            StatusId = 0;
            OnPropertyChanged(() => StatusId);
        }
    }
}
