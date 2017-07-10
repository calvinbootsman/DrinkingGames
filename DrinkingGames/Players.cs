using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace DrinkingGames
{
    public class PlayersBets
    {

        public static ObservableCollection<HorseBets> HorseBetsCollection = new ObservableCollection<HorseBets>();
    }

    public class HorseBets{
        public string Username { get; set; }
        public string Color { get; set; }
        public int sips { get; set; }
    }

}
