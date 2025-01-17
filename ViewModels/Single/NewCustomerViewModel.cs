using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Dtos;
using CarRental.Models.Services;
using Microsoft.Identity.Client;

namespace CarRental.ViewModels.Single
{
    public class NewCustomerViewModel : BaseCreateViewModel<CustomerService, CustomerDto, Customer>
    {
        public NewCustomerViewModel() : base("New Customer")
        { 
        }
        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                if (Model.FirstName != value && !value.Any(char.IsDigit)) // Any(char.IsDigit) check if any character of string is a number
                {
                    Model.FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get => Model.LastName;
            set
            {
                if (Model.LastName != value && !value.Any(char.IsDigit))
                {
                    Model.LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }
        public string Email
        {
            get => Model.Email;
            set
            {
                if (Model.Email != value)
                {
                    Model.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set
            {
                if (Model.PhoneNumber != value && value.All(char.IsDigit)) // value.All(char.IsDigit) check if all characters are numbers
                {
                    Model.PhoneNumber = value;
                    OnPropertyChanged(() => PhoneNumber);
                }
            }
        }
        public override void ResetForm()
        {
            FirstName = string.Empty;
            OnPropertyChanged(() => FirstName);
            LastName = string.Empty;
            OnPropertyChanged(() => LastName);
            Email = string.Empty;
            OnPropertyChanged(() => Email);
            PhoneNumber = string.Empty;
            OnPropertyChanged(() => PhoneNumber);

        }
    }
}
