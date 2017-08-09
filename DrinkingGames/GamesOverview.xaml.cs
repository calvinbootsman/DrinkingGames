using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class GamesOverview : ContentPage
    {
        public GamesOverview()
        {
            InitializeComponent();
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#2277FF");          

        }

        async void HorseRaceTapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PlaceBetsHorse());
        }

        async void QuestionTapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new QuestionsPage());
        }
		protected override void OnAppearing()
		{
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#2277FF");
		}
    }
}
