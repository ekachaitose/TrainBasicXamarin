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
    public partial class NavPage3 : ContentPage
    {
        public NavPage3()
        {
            InitializeComponent();
            backButton.Clicked += BackButton_Clicked;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            backButton.Navigation.PopToRootAsync();
        }
    }
}