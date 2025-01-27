using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DesktopDevelopment.Helpers;
using System.Windows.Input;
using CarRental.ViewModels.Many;
using CarRental.Views.Many;
using CarRental.Views.Single;
using CarRental.Views;

namespace CarRental.ViewModels
{
        public class MainWindowViewModel : INotifyPropertyChanged
        {
            private object _currentView;
            public object CurrentView
            {
                get => _currentView;
                set
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        public ICommand OpenDashboardViewCommand { get; }
        public ICommand OpenCustomerInfoViewCommand { get; }
        // Views Many
        public ICommand OpenCarsViewCommand { get; }
            public ICommand OpenCustomersViewCommand { get; }
            public ICommand OpenRentalsViewCommand { get; }
            public ICommand OpenReservationsViewCommand { get; }
            public ICommand OpenPaymentsViewCommand { get; }
            public ICommand OpenDiscountsViewCommand { get; }
            public ICommand OpenReviewsViewCommand { get; }
        // widoki Single
            public ICommand OpenNewCarViewCommand { get; }
            public ICommand OpenAddCustomerViewCommand { get; }
            public ICommand OpenNewPaymentViewCommand { get; }
            public ICommand OpenNewReviewViewCommand { get; }
            public ICommand OpenNewReservationViewCommand { get; }
            public ICommand OpenNewRentalViewCommand { get; }
            public ICommand OpenNewDiscountViewCommand { get; }
        public MainWindowViewModel()
            {
            // widok domyslny
                CurrentView = new Dashboard();
                OpenDashboardViewCommand = new BaseCommand(OpenDashboardView);
            OpenCustomerInfoViewCommand = new BaseCommand(OpenCustomerInfoView);
            // widoki Many
            OpenCarsViewCommand = new BaseCommand(OpenCarsView);
                OpenCustomersViewCommand = new BaseCommand(OpenCustomersView);
                OpenRentalsViewCommand = new BaseCommand(OpenRentalsView);
                OpenReservationsViewCommand = new BaseCommand(OpenReservationsView);
                OpenPaymentsViewCommand = new BaseCommand(OpenPaymentsView);
                OpenDiscountsViewCommand = new BaseCommand(OpenDiscountsView);
                OpenReviewsViewCommand = new BaseCommand(OpenReviewsView);
                // widoki Single
                OpenNewCarViewCommand = new BaseCommand(OpenNewCarView);
                OpenAddCustomerViewCommand = new BaseCommand(OpenAddCustomerView);
                OpenNewPaymentViewCommand = new BaseCommand(OpenNewPaymentView);
                OpenNewReviewViewCommand = new BaseCommand(OpenNewReviewView);
                OpenNewReservationViewCommand = new BaseCommand(OpenNewReservationView);
                OpenNewRentalViewCommand = new BaseCommand(OpenNewRentalView);
                OpenNewDiscountViewCommand = new BaseCommand(OpenNewDiscountView);
            }
        private void OpenDashboardView() => CurrentView = new Dashboard();
        private void OpenCustomerInfoView() => CurrentView = new CustomerInfoView();
        // Many views
        private void OpenCarsView() => CurrentView = new CarsView();
            private void OpenCustomersView() => CurrentView = new CustomersView();
            private void OpenRentalsView() => CurrentView = new RentalsView();
            private void OpenReservationsView() => CurrentView = new ReservationsView();
            private void OpenPaymentsView() => CurrentView = new PaymentsView();
            private void OpenDiscountsView() => CurrentView = new DiscountsView();
            private void OpenReviewsView() => CurrentView = new ReviewsView();
        // Single views
        private void OpenNewCarView() => CurrentView = new NewCarView();
        private void OpenAddCustomerView() => CurrentView = new AddCustomerView();
        private void OpenNewPaymentView() => CurrentView = new NewPaymentView();
        private void OpenNewReviewView() => CurrentView = new NewReviewView();
        private void OpenNewReservationView() => CurrentView = new NewReservationView();
        private void OpenNewRentalView() => CurrentView = new NewRentalView();
        private void OpenNewDiscountView() => CurrentView = new NewDiscountView();



            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
}
