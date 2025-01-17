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
    public class NewPaymentViewModel : BaseCreateViewModel<PaymentService, PaymentDto, Payment>
    {
        public NewPaymentViewModel() : base("New Payment")
        {
            // Statuses
            List<ComboBoxDto> statuses = Service.DatabaseContext.PaymentStatuses.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.StatusName
            }).ToList();
            _PaymentStatuses = new ObservableCollection<ComboBoxDto>(statuses);
            // Rentals
            List<ComboBoxDto> rentals = Service.DatabaseContext.Rentals.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = ""
            }).ToList();
            _Rentals = new ObservableCollection<ComboBoxDto>(rentals);
            List<ComboBoxDto> discounts = Service.DatabaseContext.Discounts.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.DiscountName + " " + item.DiscountPercentage + "%"
            }).ToList();
            _Discounts = new ObservableCollection<ComboBoxDto>(discounts);
            Date = DateTime.Now;
            OnPropertyChanged(() => Date);
        }
        public int RentalId
        {
            get => Model.RentalId;
            set
            {
                if (Model.RentalId != value)
                {
                    Model.RentalId = value;
                    OnPropertyChanged(() => RentalId);
                    _BasePrice = Service.DatabaseContext.Rentals.First(item => item.Id == RentalId).BaseAmount;
                    OnPropertyChanged(() => BasePrice);
                }
            }
        }
        public int? DiscountId
        {
            get => Model.DiscountId;
            set
            {
                if (Model.DiscountId != value)
                {
                    Model.DiscountId = value;
                    OnPropertyChanged(() => DiscountId);
                    if (_BasePrice > 0)
                    {
                        int percentage = Service.DatabaseContext.Discounts.First(item => item.Id == DiscountId).DiscountPercentage;
                        FinalPrice = _BasePrice - (_BasePrice * percentage / 100);
                        OnPropertyChanged(() => FinalPrice);
                    }
                }
            }
        }
        private decimal _BasePrice;
        public decimal BasePrice
        {
            get => _BasePrice;
            set
            {
                if (_BasePrice != value && value > 0)
                {
                    _BasePrice = value;
                    OnPropertyChanged(() => BasePrice);
                }
            }
        }
        public decimal FinalPrice
        {
            get => Model.FinalAmount;
            set
            {
                if (Model.FinalAmount != value && value > 0)
                {
                    Model.FinalAmount = value;
                    OnPropertyChanged(() => FinalPrice);
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
        public DateTime Date
        {
            get => Model.PaymentDate;
            set
            {
                if (Model.PaymentDate != value)
                {
                    Model.PaymentDate = value;
                    OnPropertyChanged(() => Date);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _PaymentStatuses;
        public ObservableCollection<ComboBoxDto> PaymentStatuses
        {
            get => _PaymentStatuses;
            set
            {
                if (_PaymentStatuses != value)
                {
                    _PaymentStatuses = value;
                    OnPropertyChanged(() => PaymentStatuses);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _Rentals;
        public ObservableCollection<ComboBoxDto> Rentals
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
        private ObservableCollection<ComboBoxDto> _Discounts;
        public ObservableCollection<ComboBoxDto> Discounts
        {
            get => _Discounts;
            set
            {
                if (_Discounts != value)
                {
                    _Discounts = value;
                    OnPropertyChanged(() => Discounts);
                }
            }
        }
        public override void ResetForm()
        {
            Model.RentalId = 0;
            OnPropertyChanged(() => RentalId);
            Model.DiscountId = null;
            OnPropertyChanged(() => DiscountId);
            _BasePrice = 0;
            OnPropertyChanged(() => BasePrice);
            FinalPrice = 0;
            OnPropertyChanged(() => FinalPrice);
            Model.StatusId = 0;
            OnPropertyChanged(() => StatusId);
        }
    }
}
