using Example.Models;
using RedGunMVVM.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Example.ViewModels
{
    public class CreateToDoPageViewModel : RedGunViewModel
    {
        private string _Title = string.Empty;

        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private string _ItemText = string.Empty;

        public string ItemText
        {
            get { return _ItemText; }
            set { SetProperty(ref _ItemText, value); }
        }

        public ICommand AddNewTodoItemCommand { get; set; }

        public CreateToDoPageViewModel()
        {
            Title = "Create ToDo Item";
            AddNewTodoItemCommand = new Command(async () =>
              {
                  var ToDoListString = await SecureStorage.GetAsync("todo_list");
                  var ToDoListData = new List<TodoItem>();
                  if (!string.IsNullOrEmpty(ToDoListString))
                  {
                      ToDoListData = System.Text.Json.JsonSerializer.Deserialize<List<TodoItem>>(ToDoListString);
                  }
                  ToDoListData.Add(new TodoItem
                  {
                      ID = System.Guid.NewGuid(),
                      Text = ItemText
                  });
                  await SecureStorage.SetAsync("todo_list", System.Text.Json.JsonSerializer.Serialize(ToDoListData));
                  var DialogCallback = await _dialogService.DisplayAlert("Notice", "Item Created Successed", "OK", "Cancel");
                  if (!DialogCallback || DialogCallback)
                  {
                      await _navigationService.PopAsync();
                  }
              });
        }
    }
}