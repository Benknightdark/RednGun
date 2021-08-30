using System.Threading.Tasks;
using Xamarin.Forms;

namespace RedGunMVVM.Services
{
    public class NavigationService
    {
        public NavigationService()
        {
        }

        #region Pop, Remove and  Insert Page

        public void InsertPageBefore(Page page, Page before)
        {
            Application.Current.MainPage.Navigation.InsertPageBefore(page, before);
        }

        public async Task<Page> PopAsync()
        {
            return await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task<Page> PopAsync(bool animated)
        {
            return await Application.Current.MainPage.Navigation.PopAsync(animated);
        }

        public async Task<Page> PopModalAsync()
        {
            return await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task<Page> PopModalAsync(bool animated)
        {
            return await Application.Current.MainPage.Navigation.PopModalAsync(animated);
        }

        public async Task PopToRootAsync()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        public async Task PopToRootAsync(bool animated)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync(animated);
        }

        public void RemovePage(Page page)
        {
            Application.Current.MainPage.Navigation.RemovePage(page);
        }

        #endregion Pop, Remove and  Insert Page

        #region Push Page

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushAsync(Page page, object parameters)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushAsync(Page page, bool animated)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page, animated);
        }

        public async Task PushAsync(Page page, object parameters, bool animated)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushAsync(page, animated);
        }

        public async Task PushAsync(NavigationPage page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushAsync(NavigationPage page, object parameters, bool animated)
        {
            page.CurrentPage.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.CurrentPage.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushAsync(page, animated);
        }

        public async Task PushAsync(NavigationPage page, object parameters)
        {
            page.CurrentPage.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.CurrentPage.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        #endregion Push Page

        #region Push Modal Page

        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PushModalAsync(Page page, object parameters)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PushModalAsync(NavigationPage page, object parameters)
        {
            page.CurrentPage.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.CurrentPage.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PushModalAsync(NavigationPage page, object parameters, bool animated)
        {
            page.CurrentPage.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.CurrentPage.BindingContext, parameters);
            await Application.Current.MainPage.Navigation.PushModalAsync(page, animated);
        }

        public async Task PushModalAsync(Page page, bool animated)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page, animated);
        }

        public async Task PushModalAsync(Page page, object parameters, bool animated)
        {
            page.BindingContext = DependencyService.Get<CommonService>().MergeObject(page.BindingContext, parameters);

            await Application.Current.MainPage.Navigation.PushModalAsync(page, animated);
        }

        #endregion Push Modal Page
    }
}