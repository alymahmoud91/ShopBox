using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using ServiceLayer.API;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;
using ServiceLayer.Models;
using ShopBoxApp.Helpers;

namespace ShopBoxApp.ViewModels
{
    public class BranchesPageViewModel : BindableBase,INavigationAware
    {
       
        #region Field

        INavigationService _navigationService;
        IPageDialogService _dialogService;
        IClientServiceCall _clientServiceCall;
        #endregion

        #region Command
        public ICommand LoadingPageommand { set; get; }
        public ICommand SelectedBranshCommand { set; get; }

        #endregion

        #region properties


        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }
        private Datum _currentBranch;

        public Datum CurrentBranch
        {
            set { _currentBranch = value; RaisePropertyChanged("CurrentBranch"); }
            get { return _currentBranch; }
        }

        private List<Datum> _branshesLst;

        public List<Datum> BranshesLst
        {
            set { _branshesLst = value; RaisePropertyChanged("BranshesLst"); }
            get { return _branshesLst; }
        }

        #endregion
        public BranchesPageViewModel(INavigationService navigationService,IPageDialogService dialogService,IClientServiceCall clientServiceCall)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _clientServiceCall = clientServiceCall;
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
            SelectedBranshCommand = new DelegateCommand(async () => { await selectedBransh(); });
        }

        private async Task selectedBransh()
        {
            await _navigationService.NavigateAsync("ProductsPage");
        }

        private async Task LoaingPage()
        {
            try
            {
            
                //check internet connection
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception("No Internet Connection");
                IsLoading = true;
                var result = await _clientServiceCall.GetAllCashRegisters(Settings.AccessToken,Settings.ClientId);
                if (result?.data.Count == 0)
                {
                    throw new Exception("no  Branshe Found");
                }
                BranshesLst = result?.data;
                RaisePropertyChanged("BranshesLst");
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;
                await _dialogService.DisplayAlertAsync("Erorr", ex.Message, "ok", "cancel");

            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
          
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
           
           
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
          
        }
        #endregion
    }
}
