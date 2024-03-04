using AndroidX.Lifecycle;
using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPage.Service;
using System.Collections.ObjectModel;
using LoginPage.Service;
using Javax.Security.Auth;
using System.Windows.Input;


namespace LoginPage.ViewModels
{
    public class UserAdminPageViewModel : ViewModel
    {
        public ObservableCollection<Player> Players { get; set; }//אוסף שחקנים
        private bool isRefreshing;
        public bool IsRefreshing { get => IsRefreshing; set => IsRefreshing = value; } //יש מצב שצריך להוסיף on property changed

        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        //צריך להוסיף פעולות

        public UserAdminPageViewModel()
        {
            Players = new ObservableCollection<Player>();

            RefreshCommand = new Command(async () => await Refresh());
            DeleteCommand= new Command((object obj)=>Delete(obj));
        }

        private async Task LoadPlayers()
        {
            LoadPlayers();
            UserService Service = new UserService();
            foreach (var player in Service.playersList)
            {
                Players.Add(player);

            }
        }

        private async Task Refresh()
        {
            IsRefreshing = true;
            await LoadPlayers();
            IsRefreshing = false;
        }

        private void Delete(object obj)
        {
            Player p=obj as Player;
            if (p != null)
            {
                Players.Remove(p);
            }
        }
 

    }
}
