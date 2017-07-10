﻿﻿﻿using System;
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
        int distance = 0;
        uint time=750;

        public HorseRacer()
        {
            InitializeComponent();
            //Make sure that the colors are correct.
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#99CC07");

        }
        protected override void OnDisappearing(){
            //Turning the colors back to normal
			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#2277FF");
        }

        void StartGame(object sender, System.EventArgs e)
        {
            //TODO: Maybe make use of the commentary
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

            //Setting the starting possitions
            Redx = 0;
            Bluex = 0;
            Purplex = 0;
            Orangex = 0;
            AnimateHorses(Redx, Bluex, Orangex, Purplex);

            //Countdown 
            int i = 3;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (i > 0)
                {
                    i = ShowSeconds(i);
                    return true;
                }
                //When the countdown is over we start the other timer and enable the horse movements.
                else
                {
                    Device.StartTimer(TimeSpan.FromMilliseconds(time + 100), () =>
               {
                   bool repeat = MoveHorses();
                   return repeat;
               });
                    return false;
                }
            });  
     }
        int ShowSeconds(int i){
            CommentaryLbl.Text = i.ToString();
            CommentaryLbl.FontSize = 32;
            return --i;
        }
        bool MoveHorses(){
            //Get the device width and make that the finnish line.
            double ddistance = Application.Current.MainPage.Width;
            distance = Convert.ToInt32(ddistance * 0.825);

            //if one of the horses already made it to the finish line then stop the timer and therefore the animation.
            if (Redx >= distance || Bluex >= distance || Purplex >= distance || Orangex >= distance){
				string[] positions = GetPositions();
				CommentaryLbl.Text = "1." + positions[3] + " 2." + positions[2] + " 3." + positions[1] + " 4." + positions[0];
                return false;
            }   
            //Make the horses move a random distance. The distance varies, but the time does not.
            var random = new System.Random();
            int range = 30;
            int MoveRed = random.Next(0, range);
            int MoveBlue = random.Next(0, range);
            int MoveOrange = random.Next(0, range);
            int MovePurple = random.Next(0, range);

            //Summing up the total distance in the Colorx vars.

            Redx += MoveRed;
            Bluex += MoveBlue;
            Purplex += MovePurple;
            Orangex += MoveOrange;
			AnimateHorses(Redx, Bluex, Orangex, Purplex);


            string[] position = GetPositions();
            CommentaryLbl.Text = "1." + position[3] + " 2." + position[2] + " 3." + position[1] + " 4." + position[0];
			return true;
        }

        async void AnimateHorses(int red, int blue, int orange, int purple){
            //Make sure that the final distance never exceeds the finnish line.
            if (red > distance) { red = distance; }
            if (blue > distance) { blue = distance; }
            if (orange > distance) { orange = distance; }
            if (purple > distance) { purple = distance; }

            /*  Here starts the animation.
                First we'll make everything move towards their random next position
                But'll also add a wiggle motion.*/
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

        string[] GetPositions(){
            int[] random = new int[4];
            random[0] = Redx;
            random[1] = Bluex;
            random[2] = Purplex;
            random[3] = Orangex;
            string[] position = new string[4];
            Array.Sort(random);

            for (int i = 0; i < 4; i++){
                if (random[i] == Redx) { position[i] = "Red"; }
                if (random[i] == Bluex) { position[i] = "Blue"; }
                if (random[i] == Purplex) { position[i] = "Purple"; }
                if (random[i] == Orangex) { position[i] = "Orange"; }
            }
            return position;
        }       
    }
}
