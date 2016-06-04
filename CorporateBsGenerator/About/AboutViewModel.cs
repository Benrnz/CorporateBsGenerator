using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CorporateBsGenerator.About
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            Icon = "about.png";
        }

        public ICommand LinkCommand
        {
            get
            {
                return new Command(OnLinkCommandExecute);
            }
        }

        public Uri WebSiteUri => new Uri("http://blog.rees.biz/p/corporate-bs-generator.html", UriKind.Absolute);


        private void OnLinkCommandExecute()
        {
            Device.OpenUri(WebSiteUri);
        }
    }
}
