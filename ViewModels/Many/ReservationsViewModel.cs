using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using DesktopDevelopment.Helpers;
using CarRental.Models.Services;

namespace CarRental.ViewModels.Many
{
    public  class ReservationsViewModel : BaseManyViewModel<ReservationService,ReservationDto,Reservation>
    {
        public ReservationsViewModel() : base("Reservations")
        {
            // Statuses
            List<ComboBoxDto> statuses = Service.DatabaseContext.ReservationStatuses.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.StatusName
            }).ToList();
            _Statuses = new ObservableCollection<ComboBoxDto>(statuses);
            List<string> columnNames = new List<string> { "Id", "Car", "Customer", "Status" };
            ColumnNames = new ObservableCollection<string>(columnNames);
        }
        public ObservableCollection<string> ColumnNames
        {
            get => Service.ColumnNames;
            set
            {
                if (Service.ColumnNames != value)
                {
                    Service.ColumnNames = value;
                    OnPropertyChanged(() => ColumnNames);
                }
            }
        }
        public string? ColumnName
        {
            get => Service.ColumnName;
            set
            {
                if (Service.ColumnName != value)
                {
                    Service.ColumnName = value;
                    OnPropertyChanged(() => ColumnName);
                }
            }
        }
        public bool Descending
        {
            get => Service.Descending;
            set
            {
                if (Service.Descending != value)
                {
                    Service.Descending = value;
                    OnPropertyChanged(() => Descending);
                }
            }
        }
        public string Customer
        {
            get => Service.Customer;
            set
            {
                if(Service.Customer != value)
                {
                    Service.Customer = value;
                    OnPropertyChanged(() => Customer);
                }
            }
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
        public string Car
        {
            get => Service.Car;
            set
            {
                if (Service.Car != value)
                {
                    Service.Car = value;
                    OnPropertyChanged(() => Car);
                }
            }
        }
        public int StatusId
        {
            get => Service.StatusId;
            set
            {
                if (Service.StatusId != value)
                {
                    Service.StatusId = value;
                    OnPropertyChanged(() =>StatusId);
                }
            }
        }
        protected override void ClearFilters()
        {
            Customer = string.Empty;
            Car = string.Empty;
            StatusId = 0;
            Descending = false;
            ColumnName = "Id";
            Refresh();
        }
    }
}
