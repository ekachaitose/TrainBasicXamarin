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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            nextButton.Clicked += NextButton_Clicked;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page2());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}