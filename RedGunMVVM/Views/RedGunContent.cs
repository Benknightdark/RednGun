using Xamarin.Forms;

namespace RedGunMVVM.Views
{
    public class RedGunContent : ContentPage
    {
        public RedGunContent()
        {
            ViewModelLocator.SetAutoWireViewModel(this, true);
        }
    }
}