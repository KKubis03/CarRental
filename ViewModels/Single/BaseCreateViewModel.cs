using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRental.Models.Services;
using DesktopDevelopment.Helpers;

namespace CarRental.ViewModels.Single
{
    public class BaseCreateViewModel<ServiceType, DtoType, ModelType>
        : BaseServiceViewModel<ServiceType, DtoType, ModelType>
        where ServiceType : BaseService<DtoType, ModelType>, new()
        where DtoType : class
        where ModelType : class, new()
    {
        private ModelType _Model;
        public ModelType Model
        {
            get => _Model;
            set
            {
                if (_Model != value)
                {
                    _Model = value;
                    OnPropertyChanged(() => Model);
                }
            }
        }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public BaseCreateViewModel(string displayName) : base(displayName)
        {
            _Model = Service.CreateModel();
            SaveCommand = new BaseCommand(() => Save());
            CancelCommand = new BaseCommand(() => Cancel());
        }
        public virtual void Save()
        {
            Service.AddModel(Model);
            ResetForm();
            OnRequestClose();
        }
        public void Cancel()
        {
            ResetForm();
            OnRequestClose();
        }
        public virtual void ResetForm() { }
    }
}
