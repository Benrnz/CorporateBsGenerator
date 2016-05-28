namespace CorporateBsGenerator.Main
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent(); // Initialise Xamarin.Forms required in every page's code behind.

            BindingContext = new MainViewModel(); // Bind to the view model. All properties refered to in Bindings will look on that class for the property name.
        }
    }
}