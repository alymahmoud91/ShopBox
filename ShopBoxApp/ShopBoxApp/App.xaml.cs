using Microsoft.Practices.Unity;
using Prism.Unity;
using ServiceLayer.API;
using ServiceLayer.Interfaces;
using ServiceLayer.Providers;
using ShopBoxApp.Views;
using Xamarin.Forms;

namespace ShopBoxApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
           // NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("UserLoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<UserLoginPage>();
            Container.RegisterType<IServiceConfiguration, ServiceConfiguration>();
            Container.RegisterType<ILoginServiceCall, LoginServiceCall>();
            Container.RegisterType<IClientServiceCall, ClientServiceCall>();
            Container.RegisterTypeForNavigation<BranchesPage>();
            Container.RegisterTypeForNavigation<ProductsPage>();
        }
    }
}
