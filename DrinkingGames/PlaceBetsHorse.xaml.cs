using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
namespace DrinkingGames
{
    public partial class PlaceBetsHorse : ContentPage
    {
		List<Entry> SipsList = new List<Entry>();
		List<Picker> ColorList = new List<Picker>();
        List<string> PlayerList = new List<string>();

        public PlaceBetsHorse()
        {
           // InitializeComponent();
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#99CC07");
            Content = MakeList();

        }
		/*protected override void OnDisappearing()
		{
			//Turning the colors back to normal
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#2277FF");
		}*/
       
        StackLayout MakeList(){
            var betLayout = new StackLayout();
            Frame frame = new Frame();
            frame = HeaderFrame();
            betLayout.Children.Add(frame);
            int size = PlayersBets.HorseBetsCollection.Count;
            int i = 0;


            Debug.WriteLine("size: "+size.ToString());

            StackLayout[] PlayerValues = new StackLayout[size];

            foreach(HorseBets bets in PlayersBets.HorseBetsCollection){
				var ColorSelection = new Picker();
				ColorSelection.Items.Add("Red");
				ColorSelection.Items.Add("Blue");
				ColorSelection.Items.Add("Purple");
				ColorSelection.Items.Add("Orange");
				var Sips = new Entry { Keyboard = Keyboard.Numeric};
				var UserNameLbl = new Label { Text = "Username: " };
				var SipsLbl = new Label { Text = " Sips: " };
				var ColorLbl = new Label { Text = " Color: " };
                var username = new Label();
                var color = bets.Color;

                Debug.WriteLine("i: "+i.ToString());
                username.Text = bets.Username;
                ColorSelection.SelectedIndex = color;
                Sips.Text = bets.Sips.ToString();
                PlayerValues[i] = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        UserNameLbl,
                        username,
                        ColorLbl,
                        ColorSelection,
                        SipsLbl,
                        Sips
                    }
                };
				StackLayout test = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					Children = {
						UserNameLbl,
						username,
						ColorLbl,
						ColorSelection,
						SipsLbl,
						Sips
					}
				};
                betLayout.Children.Add(test);
                /*           
                SipsList.Add(Sips);
                ColorList.Add(ColorSelection);
                PlayerList.Add(bets.Username);*/
                i++;
            }
            i = 0;
            for (i = 0; i < (size-1); i++){
                Debug.WriteLine("Adding to list: " + i.ToString());
				

            }
            return betLayout; 
        }
		async void GoDrink(object sender, System.EventArgs e)
		{
			int size = PlayersBets.HorseBetsCollection.Count;
			int i = 0;
			string[] Sips = new string[size];
			int[] color = new int[size];

			foreach (Entry el in SipsList)
			{
				Sips[i] = el.Text;
				i++;
			}

			i = 0;
			foreach (Picker p in ColorList)
			{
				color[i] = p.SelectedIndex;
				i++;
			}
            PlayerList.Clear();
            foreach (HorseBets h in PlayersBets.HorseBetsCollection){
                PlayerList.Add(h.Username);
            }
			i = 0;
			PlayersBets.HorseBetsCollection.Clear();
			foreach (string s in PlayerList)
			{
				PlayersBets.HorseBetsCollection.Add(new HorseBets { Username = s, Color = color[i], Sips = Convert.ToInt32(Sips[i]) });
				i++;
                Debug.WriteLine("Adding new horsebet");
			}

            await Navigation.PushAsync(new HorseRacer());
		}

        Frame HeaderFrame()
        {
            var stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            var headerText = new Label() { Text = "Place your bets", TextColor=Color.White, HorizontalOptions=LayoutOptions.CenterAndExpand };
            var buttonStack = new StackLayout();
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += GoDrink;
            buttonStack.GestureRecognizers.Add(tapGestureRecognizer);

            Label btn = new Label() { Text="Let's Drinks", TextColor=Color.White };
            Frame buttonFrame = new Frame() { HorizontalOptions = LayoutOptions.EndAndExpand, BackgroundColor = Color.FromHex("#99CC07"), Content= btn};
            buttonStack.Children.Add(buttonFrame);
            stackLayout.Children.Add(headerText);
            stackLayout.Children.Add(buttonStack);
            Frame frame = new Frame()
            {
                BackgroundColor = Color.FromHex("#99CC07"),
                Content = stackLayout
            };
			if (Device.Idiom == TargetIdiom.Phone)
			{
                frame.Padding= new Thickness(5, 5, 5, 5);
                buttonFrame.Padding = new Thickness(5, 5, 5, 5);
            }else{
                buttonFrame.Padding = new Thickness(5, 5, 5, 5);
            }

            return frame;
        }
    }
}
