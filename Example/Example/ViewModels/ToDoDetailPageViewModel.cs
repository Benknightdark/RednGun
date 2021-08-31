using Example.Models;
using RedGunMVVM.ViewModels;

namespace Example.ViewModels
{
    public class ToDoDetailPageViewModel : RedGunViewModel
    {
        private string _Title = string.Empty;

        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private TodoItem _Item = new TodoItem();

        public TodoItem Item
        {
            get => _Item;
            set
            {
                _Item = value;
                RaisePropertyChanged(nameof(Item));
            }
        }

        public ToDoDetailPageViewModel()
        {
            Title = "ToDo Detail";
        }
    }
}