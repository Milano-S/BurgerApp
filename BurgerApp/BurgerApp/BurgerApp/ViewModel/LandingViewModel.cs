using BurgerApp.Model;
using BurgerApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BurgerApp.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            burgers = GetBurgers();
        }

        ObservableCollection<Burger> burgers;
        public ObservableCollection<Burger> Burgers
        {
            get { return burgers; }
            set
            {
                burgers = value;
                OnPropertyChanged();
            }
        }

        private Burger selectedBurger;
        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                selectedBurger = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayBurger);

        private void DisplayBurger()
        {
            if (selectedBurger != null)
            {
                var viewModel = new DetailsViewModel { SelectedBurger = selectedBurger, Burgers = burgers, Position = burgers.IndexOf(selectedBurger) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Burger> GetBurgers()
        {
            return new ObservableCollection<Burger>
            {
                new Burger { Name = "BACON BONANZA", Price = 49.99f, Image = "b2.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "HEART STOPPER", Price = 74.99f, Image = "b5.png", Description = "This greasy combination of meat and cheese is guaranteed to boost your taste buds and cholesterol"},
                new Burger { Name = "ZINGER WING", Price = 64.99f, Image = "b3.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "GREEN COMA", Price = 99.99f, Image = "b1.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "THE STACK", Price = 59.99f, Image = "b4.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Burger { Name = "CHEESE OD", Price = 79.99f, Image = "b6.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"}

            };
        }
    }
}
