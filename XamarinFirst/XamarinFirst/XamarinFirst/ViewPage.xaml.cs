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
    public partial class ViewPage : ContentPage
    {
        public ViewPage()
        {
            InitializeComponent();
            okButton.Clicked += OkButton_Clicked;
            myEntry.TextChanged += MyEntry_TextChanged;
           
            var genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            genderPicker.ItemsSource = genders;

        }

        private void MyEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void OkButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Title","Message","OK");
        }
    }
}