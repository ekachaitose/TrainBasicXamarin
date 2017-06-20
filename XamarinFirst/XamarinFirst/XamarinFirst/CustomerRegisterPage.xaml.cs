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
    public partial class CustomerRegisterPage : ContentPage
    {
        public CustomerRegisterPage()
        {
            InitializeComponent();
            var genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            pickerGender.ItemsSource = genders;


           
        }

    
    }
}