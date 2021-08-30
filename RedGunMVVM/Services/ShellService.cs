using System.Threading.Tasks;
using Xamarin.Forms;

namespace RedGunMVVM.Services
{
    public class ShellService
    {
        public ShellService()
        {
        }

        #region Pop, Rmove and Insert Page

        public void InsertPageBefore(Page page, Page before)
        {
            Shell.Current.Navigation.InsertPageBefore(page, before);
        }

        public async Task<Page> PopAsync()
        {
            return await Shell.Current.Navigation.PopAsync();
        }

        public async Task<Page> PopAsync(bool animated)
        {
            return await Shell.Current.Navigation.PopAsync(animated);
        }

        public async Task<Page> PopModalAsync()
        {
            return await Shell.Current.Navigation.PopModalAsync();
        }

        public async Task<Page> PopModalAsync(bool animated)
        {
            return await Shell.Current.Navigation.PopModalAsync(animated);
        }

        public async Task PopToRootAsync()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        public async Task PopToRootAsync(bool animated)
        {
            await Shell.Current.Navigation.PopToRootAsync(animated);
        }

        public void RemovePage(Page page)
        {
            Shell.Current.Navigation.RemovePage(page);
        }

        #endregion Pop, Rmove and Insert Page

        #region PushAsync

        public async Task PushAsync(Page page)
        {
            await Shell.Current.Navigation.PushAsync(page);
        }

        public async Task PushAsync(Page page, object parameters)
        {
            page.BindingContext = parameters;
            await Shell.Current.Navigation.PushAsync(page);
        }

        public async Task PushAsync(Page page, bool animated)
        {
            await Shell.Current.Navigation.PushAsync(page, animated);
        }

        public async Task PushAsync(Page page, object parameters, bool animated)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);
            await Shell.Current.Navigation.PushAsync(page, animated);
        }

        #endregion PushAsync

        #region PushModalAsync

        public async Task PushModalAsync(Page page)
        {
            await Shell.Current.Navigation.PushModalAsync(page);
        }

        public async Task PushModalAsync(Page page, object parameters)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);
            await Shell.Current.Navigation.PushModalAsync(page);
        }

        public async Task PushModalAsync(Page page, bool animated)
        {
            await Shell.Current.Navigation.PushModalAsync(page, animated);
        }

        public async Task PushModalAsync(Page page, object parameters, bool animated)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);

            await Shell.Current.Navigation.PushModalAsync(page, animated);
        }

        #endregion PushModalAsync

        public async Task GoToAsync(string url)
        {
            await Shell.Current.GoToAsync(url);
        }
    }
}