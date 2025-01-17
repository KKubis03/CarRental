using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;
using CarRental.Models;
using System.Windows.Input;
using DesktopDevelopment.Helpers;
using CarRental.Models.Services;

namespace CarRental.ViewModels.Many
{
    public class CustomersViewModel : BaseManyViewModel<CustomerService, CustomerDto,Customer>
    {
        public CustomersViewModel() : base("Customers")
        {
        }
        public string Name
        {
            get => Service.Name;
            set
            {
                if (Service.Name != value)
                {
                    Service.Name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }
        public string Surname
        {
            get => Service.Surname;
            set
            {
                if (Service.Surname != value)
                {
                    Service.Surname = value;
                    OnPropertyChanged(() => Surname);
                }
            }
        }
        protected override void ClearFilters()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Refresh();
        }
    }
}
