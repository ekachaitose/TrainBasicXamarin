using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent(); 
            homeButton.Clicked += MenuButton_Clicked;
            navButton.Clicked += MenuButton_Clicked;
            tabButton.Clicked += MenuButton_Clicked;
            carouselButton.Clicked += MenuButton_Clicked;
            contentButton.Clicked += MenuButton_Clicked;
            preferenceButton.Clicked += MenuButton_Clicked;
            customerregisterButton.Clicked += MenuButton_Clicked;
        }


        private void MenuButton_Clicked(object sender, EventArgs e)
        {
            var mp = this.Parent as MasterDetailPage;

            if (sender == homeButton)
            {
                var np = new NavigationPage(new HomePage());
                mp.Detail = np;

            }
            else if (sender == navButton)
            {
                var np = new NavigationPage(new NavPage1());
                mp.Detail = np;
            }

            else if (sender == tabButton)
            {
                var tp = new TabbedPage();
                tp.Children.Add(new TabPage1());
                tp.Children.Add(new TabPage2());
                tp.Children.Add(new TabPage3());

                var np = new NavigationPage(tp);
                mp.Detail = np;

            }
            else if (sender == carouselButton)
            {
                var cp = new CarouselPage();
                cp.Children.Add(new TabPage1());
                cp.Children.Add(new TabPage2());
                cp.Children.Add(new TabPage3());

                var np = new NavigationPage(cp);
                mp.Detail = np;

            }
            else if (sender == contentButton)
            {
                var np = new NavigationPage(new Page1());
                mp.Detail = np;
            }
            else if (sender == preferenceButton)
            {
                var np = new NavigationPage(new PreferencePage());
                mp.Detail = np;
            }

            else if (sender == customerregisterButton)
            {
                var np = new NavigationPage(new CustomerRegisterPage());
                mp.Detail = np;
            }
            mp.IsPresented = false;

        }
    }
}