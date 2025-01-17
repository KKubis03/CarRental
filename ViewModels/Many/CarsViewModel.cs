using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;
using CarRental.Views.Many;
using CarRental.ViewModels;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using DesktopDevelopment.Helpers;
using CarRental.Models.Services;

namespace CarRental.ViewModels.Many
{
    public class CarsViewModel : BaseManyViewModel<CarService, CarDto,Car>
    {
        public CarsViewModel() : base("Cars")
        {
            // Categories
            List<ComboBoxDto> categories = Service.DatabaseContext.CarCategories.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.CategoryName
            }).ToList();
            _CarCategories = new ObservableCollection<ComboBoxDto>(categories);
            // Brands
            List<ComboBoxDto> brands = Service.DatabaseContext.CarBrands.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.CarBrandName
            }).ToList();
            _CarBrands = new ObservableCollection<ComboBoxDto>(brands);
        }
        private ObservableCollection<ComboBoxDto> _CarCategories;
        public ObservableCollection<ComboBoxDto> CarCategories
        {
            get => _CarCategories;
            set
            {
                if (_CarCategories != value)
                {
                    _CarCategories = value;
                    OnPropertyChanged(() => CarCategories);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _CarBrands;
        public ObservableCollection<ComboBoxDto> CarBrands
        {
            get => _CarBrands;
            set
            {
                if (_CarBrands != value)
                {
                    _CarBrands = value;
                    OnPropertyChanged(() => CarBrands);
                }
            }
        }
        public int CategoryId
        {
            get => Service.CategoryId;
            set
            {
                if (Service.CategoryId != value)
                {
                    Service.CategoryId = value;
                    OnPropertyChanged(() => CategoryId);
                }
            }
        }
        public int BrandId
        {
            get => Service.BrandId;
            set
            {
                if (Service.BrandId != value)
                {
                    Service.BrandId = value;
                    OnPropertyChanged(() => BrandId);
                }
            }
        }
        public bool IsAvailable
        {
            get => Service.IsAvailable;
            set
            {
                if (Service.IsAvailable != value)
                {
                    Service.IsAvailable = value;
                    OnPropertyChanged(() => IsAvailable);
                }
            }
        }
        protected override void ClearFilters()
        {
            CategoryId = 0;
            BrandId = 0;
            IsAvailable = false;
            Refresh();
        }
    }
}
