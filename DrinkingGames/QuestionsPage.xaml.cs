using System;
using System.Collections.Generic;
using PCLStorage;
using Xamarin.Forms;

namespace DrinkingGames
{
    public partial class QuestionsPage : ContentPage
    {
        public QuestionsPage()
        {
            InitializeComponent();
            try
            {
                Label lbl = QuestionLabel;
                ReadQuestions();
                var question = getAssignment();

                lbl.Text = question.Task;
                lbl.FontSize = question.TextSize;
            }
            catch (Exception es){
                
            }
        }

        void NextQuestion(object sender, System.EventArgs e)
        {
            try
            {
                var question = getAssignment();
                QuestionLabel.Text = question.Task;
                QuestionLabel.FontSize = question.TextSize;
            }
            catch(Exception es){}
        }

        async void AddQuestion(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddQuestionPage());
        }

        Assignments getAssignment(){
            var random  = new System.Random();
            var collection = AssignmentList.AssignmentCollection;
            int RandomNumber = random.Next(0, collection.Count);
            var question = collection[RandomNumber];
            AssignmentList.AssignmentCollection.RemoveAt(RandomNumber);
            return question;
        }

        async void ReadQuestions(){
            var file = await FileHandling.getFile("Question","Questions",true);
            string text = await file.ReadAllTextAsync();
            var textarray = text.Split(',');
            foreach (string s in textarray){
                var nogeenkeer = s.Split('#');
                AssignmentList.AssignmentCollection.Add(new Assignments { Task = nogeenkeer[0], TextSize = Convert.ToInt32(nogeenkeer[2]), IsTask = Convert.ToBoolean(nogeenkeer[1])});
            }
        }
    }
}
