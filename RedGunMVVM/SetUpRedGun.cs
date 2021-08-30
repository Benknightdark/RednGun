using Autofac;
using RedGunMVVM.Services;
using RedGunMVVM.ViewModels;
using Xamarin.Forms;

namespace RedGunMVVM
{
    public static class SetUpRedGun
    {
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
        /// 註冊RedGun ViewModels
        /// </summary>
        public static ContainerBuilder RegisterRedGunViewModel()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RedGunViewModel>();
            return builder;
        }

    }
}