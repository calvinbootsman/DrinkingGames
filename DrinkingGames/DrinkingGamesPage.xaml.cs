using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class DrinkingGamesPage : ContentPage
    {
        int NumberOfPlayers = 1;
        Entry[] entry = new Entry[20];
        public DrinkingGamesPage()
        {
            InitializeComponent();
            for (NumberOfPlayers =1; NumberOfPlayers <= 4; NumberOfPlayers++){
                entry[NumberOfPlayers-1] = new Entry {Placeholder="Player "+ NumberOfPlayers.ToString() };
                PlayersLayout.Children.Add(entry[NumberOfPlayers-1]);
            }

        }

        void AddPlayer(object sender, System.EventArgs e)
        {           
			entry[NumberOfPlayers-1] = new Entry { Placeholder = "Player " + NumberOfPlayers.ToString() };
			PlayersLayout.Children.Add(entry[NumberOfPlayers-1]);
			NumberOfPlayers++;
            if (NumberOfPlayers==13){
                AddPlayerBtn.IsEnabled = false;
            }
        }

        async void GoDrink(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GamesOverview());
        }
    }
}
