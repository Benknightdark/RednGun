using RedGunMVVM.ViewModels;
using Xamarin.Forms;

namespace Example.ViewModels
{
    public class CreateToDoPageViewModel:RedGunViewModel
    {
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        public CreateToDoPageViewModel() {
            Device.BeginInvokeOnMainThread(() =>
            {
                Title = "Create ToDo Item";
            });
        }
    }
}
