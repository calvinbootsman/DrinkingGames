﻿﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
namespace DrinkingGames
{
    public partial class HorseRacer : ContentPage
    {
		int Redx = 0;
		int Bluex = 0;
		int Purplex = 0;
        int Orangex = 0;
        uint time=750;
        public HorseRacer()
        {
            InitializeComponent();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#99CC07");

        }
        protected override void OnDisappearing(){
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#2277FF");
        }

        void StartGame(object sender, System.EventArgs e)
        {
            string[] Commentary = new string[]{
                "* takes the lead,",
                "* is falling behind,",
                "what is * doing?!",
                "Everyone is cheering for *, But will it be enough?",
                "It looks like we have a winner!",
                "There's no comming back for *.",
                "It's good that I'm not betting, because who have predicted that * would come back?!",
                "It look's like it's going to be photofinish.",
                "Watching paint dry is more exciting than this."
            };

            Redx = 0;
            Bluex = 0;
            Purplex = 0;
            Orangex = 0;

            Device.StartTimer(TimeSpan.FromMilliseconds(time+100),() =>
            {
                bool repeat = MoveHorses();
                return repeat;
            });
  
     }


        bool MoveHorses(){
            double ddistance = Application.Current.MainPage.Width;           
            int distance = Convert.ToInt32(ddistance)-200;

            if (Redx >= distance || Bluex >= distance || Purplex >= distance || Orangex >= distance){
                return false;
            }   
            Debug.WriteLine("Redx: " + Redx);
            var random = new System.Random();
            int range = 120;
            int MoveRed = random.Next(0, range);
            int MoveBlue = random.Next(0, range);
            int MoveOrange = random.Next(0, range);
            int MovePurple = random.Next(0, range);

            if ((Redx + MoveRed) > distance){ MoveRed = MoveRed - ((Redx - MoveRed) - distance); Redx += MoveRed; } else{ Redx += MoveRed; };
            if ((Bluex + MoveBlue) > distance) { MoveBlue = MoveBlue - ((Bluex + MoveBlue) - distance); Bluex += MoveBlue; } else { Bluex += MoveBlue; }
            if ((Purplex + MovePurple) > distance) { MovePurple = MovePurple - ((Purplex + MovePurple) - distance); Purplex += MovePurple; } else { Purplex += MovePurple; }
            if ((Orangex + MoveOrange) > distance) { MoveOrange = MoveOrange - ((Orangex + MoveOrange) - distance); Orangex += MoveOrange; } else { Orangex += MoveOrange; }
			
            AnimateHorses(Redx, Bluex, Orangex, Purplex);
			return true;
        }

        asyrn true;nc void AnimateHorses(int red, int blue, int orange, int purple){
			await Task.WhenAny(
				RedHorse.TranslateTo(red, 0, time),
                RedHorse.RotateTo(15, time/4),

				BlueHorse.TranslateTo(blue, 0, time),
                BlueHorse.RotateTo(15, time/4),

                PurpleHorse.TranslateTo(purple, 0, time),
                PurpleHorse.RotateTo(15, time/4),

                OrangeHorse.TranslateTo(orange, 0, time),
                OrangeHorse.RotateTo(15, time/4)
			);
            await Task.WhenAll(
                RedHorse.RotateTo(-30, time/2),
                BlueHorse.RotateTo(-30, time/2),
                PurpleHorse.RotateTo(-30, time/2),
                OrangeHorse.RotateTo(-30, time/2)
            );

			await Task.WhenAny(
				RedHorse.RotateTo(15, time/4),
				BlueHorse.RotateTo(15, time/4),
				PurpleHorse.RotateTo(15, time/4),
				OrangeHorse.RotateTo(15, time/4)
            );
       //             
			//await RedHorse.RotateTo(30, time);
        }

                int[4] GetPosition{

            }
    }
}
