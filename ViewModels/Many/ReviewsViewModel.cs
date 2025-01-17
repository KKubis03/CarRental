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
            Refresh();
        }
    }
}
