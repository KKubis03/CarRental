using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarRental.Models;
using CarRental.Models.Contexts;
using CarRental.Models.Dtos;
using CarRental.Models.Services;
using CarRental.Views.Single;
using Microsoft.EntityFrameworkCore;

namespace CarRental.ViewModels.Single
{
    class NewCarViewModel : BaseCreateViewModel<CarService,CarDto, Car>
    {
        public int CarBrandId
        {
            get => Model.BrandId;
            set
            {
                if (Model.BrandId != value)
                {
                    Model.BrandId = value;
                    OnPropertyChanged(() => CarBrandId);
                }
            }
        }
        public int CarModelId
        {
            get => Model.ModelId;
            set
            {
                if (Model.ModelId != value)
                {
                    Model.ModelId = value;
                    OnPropertyChanged(() => CarModelId);
                }
            }
        }
        public int CarCategoryId
        {
            get => Model.CategoryId;
            set
            {
                if (Model.CategoryId != value)
                {
                    Model.CategoryId = value;
                    OnPropertyChanged(() => CarCategoryId);
                }
            }
        }
        public string CarProductionYear
        {
            get => Model.ProductionYear;
            set
            {
                if (Model.ProductionYear!= value)
                {
                    Model.ProductionYear= value;
                    OnPropertyChanged(() => CarProductionYear);
                }
            }
        }
        public string CarLicensePlate
        {
            get => Model.LicensePlate;
            set
            {
                if (Model.LicensePlate != value)
                {
                    Model.LicensePlate = value;
                    OnPropertyChanged(() => CarLicensePlate);
                }
            }
        }
        public string CarVin
        {
            get => Model.Vin;
            set
            {
                if (Model.Vin != value)
                {
                    Model.Vin = value;
                    OnPropertyChanged(() => CarVin);
                }
            }
        }
        public int CarGearboxTypeId
        {
            get => Model.GearboxTypeId;
            set
            {
                if (Model.GearboxTypeId != value)
                {
                    Model.GearboxTypeId = value;
                    OnPropertyChanged(() => CarGearboxTypeId);
                }
            }
        }
        public int CarFuelTypeId
        {
            get => Model.FuelTypeId;
            set
            {
                if (Model.FuelTypeId != value)
                {
                    Model.FuelTypeId = value;
                    OnPropertyChanged(() => CarFuelTypeId);
                }
            }
        }
        public int CarColorId
        {
            get => Model.ColorId;
            set
            {
                if (Model.ColorId != value)
                {
                    Model.ColorId = value;
                    OnPropertyChanged(() => CarColorId);
                }
            }
        }
        public int CarStatusId
        {
            get => Model.StatusId;
            set
            {
                if (Model.StatusId != value)
                {
                    Model.StatusId = value;
                    OnPropertyChanged(() => CarStatusId);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _CarBrands;
        public ObservableCollection<ComboBoxDto> CarBrands
        {
            get => _CarBrands;
            set
            {
                if(_CarBrands != value)
                {
                    _CarBrands = value;
                    OnPropertyChanged(() => CarBrands);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _CarModels;
        public ObservableCollection<ComboBoxDto> CarModels
        {
            get => _CarModels;
            set
            {
                if (_CarModels != value)
                {
                    _CarModels = value;
                    OnPropertyChanged(() => CarModels);
                }
            }
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
        private ObservableCollection<ComboBoxDto> _Gearbox;
        public ObservableCollection<ComboBoxDto> Gearbox
        {
            get => _Gearbox;
            set
            {
                if (_Gearbox != value)
                {
                    _Gearbox = value;
                    OnPropertyChanged(() => Gearbox);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _Fuel;
        public ObservableCollection<ComboBoxDto> Fuel
        {
            get => _Fuel;
            set
            {
                if (_Fuel != value)
                {
                    _Fuel = value;
                    OnPropertyChanged(() => Fuel);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _Colors;
        public ObservableCollection<ComboBoxDto> Colors
        {
            get => _Colors;
            set
            {
                if (_Colors != value)
                {
                    _Colors = value;
                    OnPropertyChanged(() => Colors);
                }
            }
        }
        private ObservableCollection<ComboBoxDto> _Statuses;
        public ObservableCollection<ComboBoxDto> Statuses
        {
            get => _Statuses;
            set
            {
                if (_Statuses != value)
                {
                    _Statuses = value;
                    OnPropertyChanged(() => Statuses);
                }
            }
        }
        public NewCarViewModel() : base("New Car")
        {
            // Brands
            List<ComboBoxDto> brands = Service.DatabaseContext.CarBrands.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.CarBrandName
            }).ToList();
            _CarBrands = new ObservableCollection<ComboBoxDto>(brands);
            // Models
            List<ComboBoxDto> models = Service.DatabaseContext.CarModels.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.CarModelName
            }).ToList();
            _CarModels = new ObservableCollection<ComboBoxDto>(models);
            // Categories
            List<ComboBoxDto> categories = Service.DatabaseContext.CarCategories.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.CategoryName
            }).ToList();
            _CarCategories = new ObservableCollection<ComboBoxDto>(categories);
            // Gearbox
            List<ComboBoxDto> gearbox = Service.DatabaseContext.GearboxTypes.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.GearboxName
            }).ToList();
            _Gearbox = new ObservableCollection<ComboBoxDto>(gearbox);
            // Fuel
            List<ComboBoxDto> fuel = Service.DatabaseContext.FuelTypes.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.FuelName
            }).ToList();
            _Fuel = new ObservableCollection<ComboBoxDto>(fuel);
            // Colors
            List<ComboBoxDto> colors = Service.DatabaseContext.Colors.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.ColorName
            }).ToList();
            _Colors = new ObservableCollection<ComboBoxDto>(colors);
            // Statuses
            List<ComboBoxDto> statuses = Service.DatabaseContext.CarStatuses.Where(item => item.IsActive).Select(item => new ComboBoxDto()
            {
                Id = item.Id,
                Title = item.StatusName
            }).ToList();
            _Statuses = new ObservableCollection<ComboBoxDto>(statuses);
        }
        public override void ResetForm()
        {
            CarBrandId = 0;
            OnPropertyChanged(() => CarBrandId);
            CarModelId = 0;
            OnPropertyChanged(() => CarModelId);
            CarCategoryId = 0;
            OnPropertyChanged(() => CarCategoryId);
            CarProductionYear = string.Empty;
            OnPropertyChanged(() => CarProductionYear);
            CarLicensePlate = string.Empty;
            OnPropertyChanged(() => CarLicensePlate);
            CarVin = string.Empty;
            OnPropertyChanged(() => CarVin);
            CarGearboxTypeId = 0;
            OnPropertyChanged(() => CarGearboxTypeId);
            CarFuelTypeId = 0;
            OnPropertyChanged(() => CarFuelTypeId);
            CarColorId = 0;
            OnPropertyChanged(() => CarColorId);
            CarStatusId = 0;
            OnPropertyChanged(() => CarStatusId);
        }

    }
}
