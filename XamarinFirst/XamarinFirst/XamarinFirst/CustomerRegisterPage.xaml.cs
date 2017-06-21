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
            cancelButton.Clicked += CancelButton_Clicked;
            var genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            genderPicker.ItemsSource = genders;
        }

       async private void CancelButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Confirm", "Do you want to cancel ?", "OK", "Cancel");
            if (isOk)
            {
                var np = this.Parent as NavigationPage;
                var mp = np.Parent as MasterDetailPage;
                mp.Detail = new NavigationPage(new CustomerListPage());
            }
        }

        async private void SaveButton_Clicked(object sender, EventArgs e)
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
            //โชว์ อินดิเคเตอร์ เพื่อป้องกันการกดซ้ำ
            saveButton.IsEnabled = false;
            saveIndicator.IsVisible = true;
            var id = await Helpers.DbHelper.Current.CustomerAdd(customer);
            saveButton.IsEnabled = true;
            saveIndicator.IsVisible = false;
            if (id > 0)
            {
               await DisplayAlert("Complete", $"Register Success #{id}", "OK");
                var np = this.Parent as NavigationPage;
                var mp = np.Parent as MasterDetailPage;
                mp.Detail = new NavigationPage(new CustomerListPage());

            }
            else await DisplayAlert("Warning", "Something wrong", "OK");
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