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
    public partial class CustomerListPage : ContentPage
    {
        public CustomerListPage()
        {
            InitializeComponent();
            addButton.Clicked += AddButton_Clicked;
            searchEntry.TextChanged += SearchEntry_TextChanged;
            listView.Refreshing += ListView_Refreshing;
            FeedData();
        }

        private  void ListView_Refreshing(object sender, EventArgs e)
        {

            FeedData();
        }

        async void FeedData()
        {
            listView.IsRefreshing = true;
           await Helpers.DbHelper.Current.FeedData();  //เก็บ data ลง db SQLite
            listView.ItemsSource = Helpers.DbHelper.Current.CustomerGet(); //ดึง data จาก db SQLite
            listView.IsRefreshing = false;
        }

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = Helpers.DbHelper.Current.CustomerSearch(searchEntry.Text);
        }


        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var np = this.Parent as NavigationPage;
            var mp = np.Parent as MasterDetailPage;
            mp.Detail = new NavigationPage(new CustomerRegisterPage());
        }
    }
}