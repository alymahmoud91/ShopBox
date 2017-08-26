using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Prism.Navigation;
using Prism.Services;
using ServiceLayer.API;
using ServiceLayer.Models;
using ShopBoxApp.Helpers;

namespace ShopBoxApp.ViewModels
{
    public class ProductsPageViewModel : BindableBase
    {
        #region Field

        INavigationService _navigationService;
        IPageDialogService _dialogService;
        IClientServiceCall _clientServiceCall;
        #endregion
        #region Command
        public ICommand LoadingPageommand { set; get; }


        #endregion
        #region properties


        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        private List<Product> _productsLst;

        public List<Product> ProductsLst
        {
            set { _productsLst = value; RaisePropertyChanged("ProductsLst"); }
            get { return _productsLst; }
        }

        #endregion
        public ProductsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IClientServiceCall clientServiceCall)
        {
            _navigationService = navigationService;
            _clientServiceCall = clientServiceCall;
            _dialogService = dialogService;
            InitCommand();
            LoadingPageommand.Execute(null);
        }

        #region Method
        private void InitCommand()
        {
            LoadingPageommand = new DelegateCommand(async () =>
            {
                await LoaingPage();
            });
        }
        private async Task LoaingPage()
        {
            try
            {
              
                //check internet connection
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception("No Internet Connection");
                IsLoading = true;
                var result = await _clientServiceCall.GetAllProducts(Settings.AccessToken, Settings.ClientId);
                if (result?.products.Count == 0)
                {
                    throw new Exception("no  Branshe Found");
                }
                ProductsLst = result?.products;
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;
                await _dialogService.DisplayAlertAsync("Erorr", ex.Message, "ok", "cancel");

            }
        }
        #endregion
    }
}
