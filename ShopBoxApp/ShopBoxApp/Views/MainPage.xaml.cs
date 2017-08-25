using ServiceLayer.Models;
using ShopBoxApp.ViewModels;
using Xamarin.Forms;

namespace ShopBoxApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (BindingContext == null) return;
            (BindingContext as MainPageViewModel).CurrentClient = e.Item as Client;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
