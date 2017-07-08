using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class DrinkingGamesPage : ContentPage
    {
        int NumberOfPlayers = 1;
        Entry[] entry = new Entry[12];
        public DrinkingGamesPage()
        {
            InitializeComponent();
            for (NumberOfPlayers =1; NumberOfPlayers <= 4; NumberOfPlayers++){
                entry[NumberOfPlayers] = new Entry {Placeholder="Player "+ NumberOfPlayers.ToString() };
                PlayersLayout.Children.Add(entry[NumberOfPlayers]);
            }

        }

        void AddPlayer(object sender, System.EventArgs e)
        {
            NumberOfPlayers++;
			entry[NumberOfPlayers] = new Entry { Placeholder = "Player " + NumberOfPlayers.ToString() };
			PlayersLayout.Children.Add(entry[NumberOfPlayers]);
        }
    }
}
