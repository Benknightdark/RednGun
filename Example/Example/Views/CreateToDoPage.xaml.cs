using RedGunMVVM.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Example.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateToDoPage : RedGunContent
    {
        public CreateToDoPage()
        {
            InitializeComponent();
        }
    }
}