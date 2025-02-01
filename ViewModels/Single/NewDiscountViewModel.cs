using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Dtos;
using CarRental.Models.Services;

namespace CarRental.ViewModels.Single
{
    public class NewDiscountViewModel : BaseCreateViewModel<DiscountService,DiscountDto,Discount>
    {
        public NewDiscountViewModel() : base("New Discount") { }
        public int DiscountPercentage
        {
            get => Model.DiscountPercentage;
            set
            {
                if (Model.DiscountPercentage != value && value <= 100 && value >= 0)
                {
                    Model.DiscountPercentage = value;
                    OnPropertyChanged(() => DiscountPercentage);
                }
            }
        }
        public string DiscountName
        {
            get => Model.DiscountName;
            set
            {
                if (Model.DiscountName != value)
                {
                    Model.DiscountName = value;
                    OnPropertyChanged(() => DiscountName);
                }
            }
        }
        public override void ResetForm()
        {
            DiscountPercentage = 0;
            OnPropertyChanged(() => DiscountPercentage);
            DiscountName = string.Empty;
            OnPropertyChanged(() => DiscountName);
        }
    }
}
