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
    public class DiscountsViewModel : BaseManyViewModel<DiscountService, DiscountDto,Discount>
    {
        public DiscountsViewModel() : base("Discounts")
        {
            List<string> columnNames = new List<string> { "Id", "Name","Percentage"};
            ColumnNames = new ObservableCollection<string>(columnNames);
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
        public int Percentage
        {
            get => Service.Percentage;
            set
            {
                if (Service.Percentage != value)
                {
                    Service.Percentage = value;
                    OnPropertyChanged(() => Percentage);
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
        protected override void ClearFilters()
        {
            Name = string.Empty;
            Percentage = 0;
            Descending = false;
            ColumnName = "Id";
            Refresh();
        }
    }
}
