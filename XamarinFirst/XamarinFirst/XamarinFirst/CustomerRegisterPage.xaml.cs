using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirst.Models;

namespace XamarinFirst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerRegisterPage : ContentPage
    {
        public CustomerRegisterPage()
        {
            InitializeComponent();

            childrenStepper.ValueChanged += ChildrenStepper_ValueChanged;
            salarySlider.ValueChanged += SalarySlider_ValueChanged;
            saveButton.Clicked += SaveButton_Clicked;

            var genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            genderPicker.ItemsSource = genders;
        }

      

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = nameEntry.Text,
                Surname = surnameEntry.Text,
                Birthdate = birthdatePicker.Date,
                Email = emailEntry.Text,
                Telephone = telephoneEntry.Text,
                IsMarry = marrySwitch.IsToggled,
                Salary = (int)salarySlider.Value,
                Children = (int)childrenStepper.Value,
                Gender = genderPicker.SelectedItem.ToString(),
                Photo = "",
                Address = addressEditor.Text,
                Website = websiteEntry.Text,
                Username = usernameEntry.Text,
                Password = passwordEntry.Text

            };

            var affected = Helpers.DbHelper.Current.CustomerAdd(customer);
            if (affected > 0) DisplayAlert("Complete", "Register Success", "OK");
           else DisplayAlert("Warning", "Something wrong", "OK");
        }

        void ChildrenStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            childrenLabel.Text = $"Children: {e.NewValue}";
        }

        void SalarySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            salaryLabel.Text = string.Format("Salary: {0:N0} Baht", e.NewValue);
        }
    }
}