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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            nextButton.Clicked += NextButton_Clicked;
            backButton.Clicked += BackButton_Clicked;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();   
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page3());
        }
    }
}