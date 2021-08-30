using Example.ViewModels;
using Example.Views;
using RedGunMVVM;
using Xamarin.Forms;

namespace Example
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetUpRedGun.RegisterRedGunServices();

            SetUpRedGun.RegisterBaseRedGunViewModels();

            SetUpRedGun.RegisterRedGunViewModel<CreateToDoPageViewModel>();

            SetUpRedGun.RegsiterViewModelLocatorDependencies();

            MainPage = new NavigationPage(new CreateToDoPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}