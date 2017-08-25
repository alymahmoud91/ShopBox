using ServiceLayer.Models;
using ShopBoxApp.ViewModels;
using Xamarin.Forms;

namespace ShopBoxApp.Views
{
    public partial class BranchesPage : ContentPage
    {
        public BranchesPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (BindingContext == null) return;
            (BindingContext as BranchesPageViewModel).CurrentBranch = e.Item as BranchesRoot.Datum;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
