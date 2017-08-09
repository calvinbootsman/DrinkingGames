using System;
using System.Collections.Generic;
using PCLStorage;
using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
			var file = await FileHandling.getFile("Question", "Questions", true);
            string text = await file.ReadAllTextAsync();
            text = text + QuestionEntry.Text + "#1#" + SizeEntry.Text+",";
            await file.WriteAllTextAsync(text);
        }
    }
}
