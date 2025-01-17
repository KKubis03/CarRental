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

namespace CarRental.ViewModels.Single
{
    public class NewReviewViewModel : BaseCreateViewModel<ReviewService,ReviewDto,Review>
    {
        public NewReviewViewModel() : base("New Review")
        {
            // Rentals
            List<ComboBoxDto> rentals = Service.DatabaseContext.Rentals.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = ""
            }).ToList();
            _Rentals = new ObservableCollection<ComboBoxDto>(rentals);
            SetRating1Command = new BaseCommand(() => SetRating(1));
            SetRating2Command = new BaseCommand(() => SetRating(2));
            SetRating3Command = new BaseCommand(() => SetRating(3));
            SetRating4Command = new BaseCommand(() => SetRating(4));
            SetRating5Command = new BaseCommand(() => SetRating(5));
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
        public string Content
        {
            get => Model.Content;
            set
            {
                if (Model.Content != value)
                {
                    Model.Content = value;
                    OnPropertyChanged(() => Content);
                }
            }
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
                }
            }
        }
        public int Rating
        {
            get => Model.Rating;
            set
            {
                if(Model.Rating != value && value > 0)
                {
                    Model.Rating = value;
                    OnPropertyChanged(() => Rating);
                }
            }
        }
        public ICommand SetRating5Command{ get; set; }
        public ICommand SetRating4Command { get; set; }
        public ICommand SetRating3Command { get; set; }
        public ICommand SetRating2Command { get; set; }
        public ICommand SetRating1Command { get; set; }
        private void SetRating(int rating)
        {
            Model.Rating = rating;
        }
        public override void ResetForm()
        {
            Content = string.Empty;
            OnPropertyChanged(() => Content);
            RentalId = 0;
            OnPropertyChanged(() => RentalId);
            Rating = 0;
            OnPropertyChanged(() => Rating);
        }
    }
}
