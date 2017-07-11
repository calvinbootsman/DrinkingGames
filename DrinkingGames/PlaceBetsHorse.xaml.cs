using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class PlaceBetsHorse : ContentPage
    {
        public PlaceBetsHorse()
        {
            InitializeComponent();
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#99CC07");
            MakeList();
            UsernameList.ItemsSource = PlayersBets.HorseBetsCollection;

        }
		protected override void OnDisappearing()
		{
			//Turning the colors back to normal
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#2277FF");
		}

        async void MakeList(){
            Picker colorPicker = ColorPicker;

        }

    }
}
