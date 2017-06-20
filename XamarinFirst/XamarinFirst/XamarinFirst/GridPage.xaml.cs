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
    public partial class GridPage : ContentPage
    {
        public GridPage()
        {
            InitializeComponent();
            //if (Device.RuntimePlatform == "iOS")
            //{
            //    this.Padding = new Thickness(10, 20, 10, 10);
            //}
            //else
            //{
            //    this.Padding = new Thickness(10, 10, 10, 10);
            //}
            
        }
    }
}