using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRental.Models;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;
using CarRental.Models.Services;
using DesktopDevelopment.Helpers;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRental.ViewModels.Many
{
    public class PaymentsViewModel : BaseManyViewModel<PaymentService,PaymentDto,Payment>
    {
        public PaymentsViewModel() : base("Payments")
        {
            // Statuses
            List<ComboBoxDto> statuses = Service.DatabaseContext.PaymentStatuses.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.StatusName
            }).ToList();
            _Statuses = new ObservableCollection<ComboBoxDto>(statuses);
            List<string> columnNames = new List<string> { "Id", "Base price","Final price", "Discount", "Rental", "Date" };
            ColumnNames = new ObservableCollection<string>(columnNames);
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
        public decimal MinBasePrice
        {
            get => Service.MinBasePrice;
            set
            {
                if (Service.MinBasePrice != value)
                {
                    Service.MinBasePrice = value;
                    OnPropertyChanged(() => MinBasePrice);
                }
            }
        }
        public decimal MaxBasePrice
        {
            get => Service.MaxBasePrice;
            set
            {
                if (Service.MaxBasePrice != value)
                {
                    Service.MaxBasePrice = value;
                    OnPropertyChanged(() => MaxBasePrice);
                }
            }
        }
        public decimal MinFinalPrice
        {
            get => Service.MinFinalPrice;
            set
            {
                if (Service.MinFinalPrice != value)
                {
                    Service.MinFinalPrice = value;
                    OnPropertyChanged(() => MinFinalPrice);
                }
            }
        }
        public decimal MaxFinalPrice
        {
            get => Service.MaxFinalPrice;
            set
            {
                if (Service.MaxFinalPrice != value)
                {
                    Service.MaxFinalPrice = value;
                    OnPropertyChanged(() => MaxFinalPrice);
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
                    OnPropertyChanged(() => StatusId);
                }
            }
        }
        public DateTime? DateFrom
        {
            get => Service.DateFrom;
            set
            {
                if (Service.DateFrom != value)
                {
                    Service.DateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }
        public DateTime? DateTo
        {
            get => Service.DateTo;
            set
            {
                if (Service.DateTo != value)
                {
                    Service.DateTo = value;
                    OnPropertyChanged(() => DateTo);
                }
            }
        }

        protected override void ClearFilters()
        {
            MinBasePrice = 0;
            MaxBasePrice = 0;
            MinFinalPrice = 0;
            MaxFinalPrice = 0;
            StatusId = 0;
            DateFrom = null;
            DateTo = null;
            ColumnName = "Id";
            Descending = false;
            Refresh();
        }
    }
}
