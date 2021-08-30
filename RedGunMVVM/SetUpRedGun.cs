using Autofac;
using RedGunMVVM.Services;
using RedGunMVVM.ViewModels;
using Xamarin.Forms;

namespace RedGunMVVM
{
    public static class SetUpRedGun
    {
        private static ContainerBuilder Builder = new ContainerBuilder();

        /// <summary>
        /// 註冊RedGun服務
        /// </summary>
        public static void RegisterRedGunServices()
        {
            DependencyService.Register<CommonService>();
            DependencyService.Register<DialogService>();
            DependencyService.Register<NavigationService>();
            DependencyService.Register<ShellService>();
        }

        /// <summary>
        /// 註冊Base RedGun ViewModels
        /// </summary>
        public static void RegisterBaseRedGunViewModels()
        {
            Builder.RegisterType<RedGunViewModel>();
        }

        /// <summary>
        /// 註冊RedGun ViewModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RegisterRedGunViewModel<T>()
        {
            Builder.RegisterType<T>();
        }

        /// <summary>
        /// 註冊ViewModelLocator Dependencies
        /// </summary>
        /// <param name="RedGunViewModels"></param>
        public static void RegsiterViewModelLocatorDependencies()
        {
            ViewModelLocator.RegisterDependencies(Builder);
        }
    }
}