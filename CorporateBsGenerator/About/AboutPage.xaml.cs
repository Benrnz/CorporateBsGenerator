using Xamarin.Forms;

namespace CorporateBsGenerator.About
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method that is called when the binding context changes.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var viewModel = (AboutViewModel) BindingContext;
            if (viewModel == null) return;

            var gesture = new TapGestureRecognizer
            {
                Command = viewModel.LinkCommand,
            };
            this.WebLink.GestureRecognizers.Add(gesture);
        }
    }
}