using Example.Models;
using Example.Views;
using RedGunMVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Example.ViewModels
{
    public class ToDoListPageViewModel : RedGunViewModel
    {
        private string _Title = string.Empty;

        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private ObservableCollection<TodoItem> _TodoListItems = new ObservableCollection<TodoItem>();

        public ObservableCollection<TodoItem> TodoListItems
        {
            get => _TodoListItems;
            set
            {
                _TodoListItems = value;
                RaisePropertyChanged(nameof(TodoListItems));
            }
        }

        public ICommand GoToCreateToDoPageCommand { get; set; }

        public ToDoListPageViewModel()
        {
            Title = "ToDo List";
            Device.BeginInvokeOnMainThread(async () =>
            {
                var ToDoListString = await SecureStorage.GetAsync("todo_list");
                if (!string.IsNullOrEmpty(ToDoListString))
                {
                    var ToDoListData = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<TodoItem>>(ToDoListString);
                    TodoListItems = ToDoListData;
                }

            });
            GoToCreateToDoPageCommand = new Command(async () =>
              {
                  await _navigationService.PushAsync(new CreateToDoPage());
              });
        }
    }
}