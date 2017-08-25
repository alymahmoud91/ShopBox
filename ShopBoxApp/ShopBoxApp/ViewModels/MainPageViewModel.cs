using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Services;
using ServiceLayer.API;
using System.Threading.Tasks;
using Plugin.Connectivity;
using ServiceLayer.Models;
using ShopBoxApp.Helpers;
using Xamarin.Forms;

namespace ShopBoxApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Field

        INavigationService _navigationService;
        IPageDialogService _dialogService;
        IClientServiceCall _clientServiceCall;
        #endregion

        #region Properties

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }
        private Client _currentclient;

        public Client CurrentClient
        {
            set { _currentclient = value; RaisePropertyChanged("CurrentClient"); } get { return _currentclient; }
        }
        private List<Client>_myClients;

        public List<Client> MyClients
        {
            set { _myClients = value; RaisePropertyChanged("MyClients"); }
            get { return _myClients;  }
        }

        #endregion

        #region Command
        public ICommand LoadingPageommand { set; get; }
        public ICommand SelectedClientCommand
        {
            set; get;
        }
        #endregion
        public MainPageViewModel(IClientServiceCall clientServiceCall, INavigationService navigationService,IPageDialogService dialogService )
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _clientServiceCall = clientServiceCall;
            CurrentClient=new Client();
            InitCommand();
            LoadingPageommand.Execute(null);
        }
        #region Method

        private void InitCommand()
        {
            LoadingPageommand=new DelegateCommand(async () =>
            {
                await LoaingPage();
            });
            SelectedClientCommand=new DelegateCommand(async () => { await selectedClient(); });
        }

        private async Task selectedClient()
        {
            
            Settings.ClientId=CurrentClient?.client?.taxes[0]?.client.ToString();
            await _navigationService.NavigateAsync("BranchesPage");
        }

        private async Task LoaingPage()
        {
            try
            {
                // to privent multi click in button
                if (IsLoading)
                    return;
                //check internet connection
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception("No Internet Connection");
                IsLoading = true;
               var Result= await _clientServiceCall.GetAllStores(Settings.AccessToken);
                MyClients = Result?.clients;
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;
                await _dialogService.DisplayActionSheetAsync("Erorr", ex.Message, "ok", "cancel");
               
            }
        }
        #endregion


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
