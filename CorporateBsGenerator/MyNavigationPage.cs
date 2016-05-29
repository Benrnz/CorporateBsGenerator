using Xamarin.Forms;

namespace CorporateBsGenerator
{
    public class MyNavigationPage : NavigationPage
    {
        public MyNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public MyNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Color.FromHex("#03A9F4");
            BarTextColor = Color.White;
        }
    }
}
