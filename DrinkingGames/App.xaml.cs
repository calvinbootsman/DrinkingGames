using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DrinkingGamesPage()){BarBackgroundColor = Color.FromHex("2277FF"), BarTextColor=Color.White};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
