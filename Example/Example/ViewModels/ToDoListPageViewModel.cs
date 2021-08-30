using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Example.Models;
using Example.Views;
using RedGunMVVM.ViewModels;
using Xamarin.Forms;

namespace Example.ViewModels
{
   public  class ToDoListPageViewModel:RedGunViewModel
    {
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        ObservableCollection<TodoItem> _TodoListItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> TodoListItems
        {
            get => _TodoListItems;
            set
            {
                _TodoListItems = value;
                RaisePropertyChanged(nameof(TodoListItems));
            }
        }
        public ICommand GoToCreateToDoPageCommand;
        public ToDoListPageViewModel() {
            Device.BeginInvokeOnMainThread(() =>
            {
                Title = "ToDo List";
            });
            GoToCreateToDoPageCommand = new Command(async () =>
              {
                  await _navigationService.PushAsync(new CreateToDoPage());
              });
        }
    }
}
