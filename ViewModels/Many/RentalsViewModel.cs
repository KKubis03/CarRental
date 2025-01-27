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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.ViewModels.Many
{
    public class RentalsViewModel : BaseManyViewModel<RentalService,RentalDto,Rental>
    {
        public RentalsViewModel() : base("Rentals")
        {
            List<string> columnNames = new List<string> { "Id", "Car","Customer","Price" };
            ColumnNames = new ObservableCollection<string>(columnNames);
        }
        public decimal MinPrice
        {
            get => Service.MinPrice;
            set
            {
                if(Service.MinPrice != value)
                {
                    Service.MinPrice = value;
                    OnPropertyChanged(() => MinPrice);
                }
            }
        }
        public decimal MaxPrice
        {
            get => Service.MaxPrice;
            set
            {
                if (Service.MaxPrice != value)
                {
                    Service.MaxPrice = value;
                    OnPropertyChanged(() => MaxPrice);
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
            MinPrice = 0;
            MaxPrice = 0;
            Descending = false;
            ColumnName = "Id";
            Refresh();
        }
    }
}
