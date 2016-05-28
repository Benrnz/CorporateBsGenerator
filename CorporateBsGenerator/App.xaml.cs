using CorporateBsGenerator.Main;
using Xamarin.Forms;
using MainPage = CorporateBsGenerator.Main.MainPage;

namespace CorporateBsGenerator
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			// The root page of your application
            MainPage = new MainPage { BindingContext = new MainViewModel() };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

