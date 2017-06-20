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
    public partial class NavPage1 : ContentPage
    {
        public NavPage1()
        {
            InitializeComponent();
            nextButton.Clicked += NextButton_Clicked;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavPage2());
        }
    }
}