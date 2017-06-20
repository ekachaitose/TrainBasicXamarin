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
    public partial class PreferencePage : ContentPage
    {
        public PreferencePage()
        {
            InitializeComponent();
            saveButton.Clicked += SaveButton_Clicked;

            nameEntry.Text = Helpers.Settings.Name;
            ageEntry.Text = Helpers.Settings.Age.ToString();
            object path;
            Application.Current.Properties.TryGetValue("Path", out path);
            pathEditor.Text = path == null ? "" : path.ToString() ;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Helpers.Settings.Name = nameEntry.Text;
            Helpers.Settings.Age = int.Parse(ageEntry.Text);
            DisplayAlert("", "save success", "OK");
        }
    }
}