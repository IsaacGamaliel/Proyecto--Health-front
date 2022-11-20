using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views.Dietas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dietas : ContentPage
    {
        public Dietas()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var url = "https://drive.google.com/file/d/1igP-45xHkoCi99Fxi0yDIBFELfn5kRyh/view?usp=share_link";
            Device.OpenUri(new Uri(url));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var url = "https://drive.google.com/file/d/1R_UKB6EU6PZwq5De10-WGNLvTp838kb8/view?usp=share_link";
            Device.OpenUri(new Uri(url));
        }
    }
}