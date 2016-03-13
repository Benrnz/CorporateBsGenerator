using System;
using System.ComponentModel;
using System.Globalization;
using CorporateBsGenerator.Services;
using Xamarin.Forms;

namespace CorporateBsGenerator.View
{
    public partial class MainPage : ContentPage
    {
        private readonly GeneratorService _service = new GeneratorService();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Title = "Corporate BS Generator";
        }

        public string MainText => "Welcome to the Corporate Bull-shit Generator.";

        public string Instructions => "Prepare to catapult your career into the stratosphere!";

        private void OnGenerateClicked(object sender, EventArgs e)
        {
            var statement = _service.Generate();
            var firstLetter = statement.ToCharArray(0, 1);
            var theRest = statement.ToCharArray(1, statement.Length - 1);
			firstLetter[0] = char.ToUpper(firstLetter[0]);
            LabelResult.Text = new string(firstLetter) + new string(theRest) + ".";
        }
    }
}
