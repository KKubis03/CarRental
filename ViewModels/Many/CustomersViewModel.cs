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
            List<string> columnNames = new List<string> {"Id","Name", "Surname","Phone", "Email"};
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
            ColumnName = "Id";
            Descending = false;
            Refresh();
        }
    }
}
