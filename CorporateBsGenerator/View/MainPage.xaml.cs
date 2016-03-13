using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CorporateBsGenerator.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Title = "Corporate BS Generator";
        }

        public string MainText => "Welcome to the Corporate Bull-shit Generator.";

        public string Instructions => "Prepare to catapult your career into the stratosphere!";
    }
}
