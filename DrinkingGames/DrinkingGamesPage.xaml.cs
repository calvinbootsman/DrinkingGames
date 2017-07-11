using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int size = entry.Length;
            Debug.WriteLine(NumberOfPlayers.ToString());
            PlayersBets.HorseBetsCollection.Clear();
            for (int i = 0; i < (NumberOfPlayers - 1); i++)
            {
                Debug.WriteLine(i.ToString());
                if (System.String.IsNullOrEmpty(entry[i].Text)) { }else{
                    PlayersBets.HorseBetsCollection.Add(new HorseBets { Username = entry[i].Text, Color = 0, Sips = 0 });

                    Debug.WriteLine(entry[i].Text+i.ToString());
                }

            }
            await Navigation.PushAsync(new GamesOverview());
        }
    }
}
