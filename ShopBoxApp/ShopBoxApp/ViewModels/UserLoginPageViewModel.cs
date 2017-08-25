using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using Plugin.Connectivity;
using ServiceLayer.API;
using ServiceLayer.Models;
using ShopBoxApp.Helpers;

namespace ShopBoxApp.ViewModels
{
    public class UserLoginPageViewModel : BindableBase
    {
        #region Field
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;
        ILoginServiceCall _loginServiceCall;
        #endregion

        #region Properties
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Command
        public ICommand LoginCommand { set; get; }
        #endregion
        public UserLoginPageViewModel(ILoginServiceCall loginServiceCall, INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _loginServiceCall = loginServiceCall;
            InitCommand();
            Username = "test@shopbox.com";
            Password = "123456";

        }

        #region Method
        private void InitCommand()
        {
            LoginCommand = new DelegateCommand(async () => await Login());
        }
        public async Task Login()
        {

            try
            {

                // to privent multi click in button
                if (IsLoading)
                    return;
                //check internet connection
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception("No Internet Connection");
                if (string.IsNullOrEmpty(Username) || string.IsNullOrWhiteSpace(Username))
                {
                    throw new Exception("username is empty !");
                }
                IsLoading = true;
                User result = await _loginServiceCall.Authenticate(Username, Password);
                IsLoading = false;

                if (string.IsNullOrEmpty(result?.accessToken))
                    throw new Exception("Invalid Access");

                Settings.AccessToken = result?.accessToken;
                //    var parameter = new NavigationParameters();
                //    parameter.Add("userInfo", result);
                await _navigationService.NavigateAsync("MainPage");
            }
            catch (Exception ex)
            {
                IsLoading = false;
                await _pageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok", "Cancel");
            }

        }
        #endregion
    }
}
