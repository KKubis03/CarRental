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
    public class ReviewsViewModel : BaseManyViewModel<ReviewService,ReviewDto,Review>
    {
        public ReviewsViewModel() : base("Reviews")
        {
            List<string> columnNames = new List<string> { "Id", "Content", "Rating", "RentalId"};
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
        public string Content
        {
            get => Service.Content;
            set
            {
                if (Service.Content != value)
                {
                    Service.Content = value;
                    OnPropertyChanged(() => Content);
                }
            }
        }
        public int Rating
        {
            get => Service.Rating;
            set
            {
                if (Service.Rating != value)
                {
                    Service.Rating = value;
                    OnPropertyChanged(() => Rating);
                }
            }
        }
        protected override void ClearFilters()
        {
            Content = string.Empty;
            Rating = 0;
            Descending = false;
            ColumnName = "Id";
            Refresh();
        }
    }
}
