using System.Threading.Tasks;
using Xamarin.Forms;

namespace RedGunMVVM.Services
{
    public class DialogService
    {
        public DialogService()
        {
        }

        public async Task<string> DisplayActionSheet(string title, string cancel,
            string destruction, params string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancel,
             destruction, buttons);
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
        {
            return await Application.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, initialValue: initialValue, maxLength: maxLength, keyboard: keyboard);
        }
    }
}