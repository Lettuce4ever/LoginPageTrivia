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

using System.Windows.Input;


namespace LoginPage.ViewModels
{
    public class UserAdminPageViewModel : ViewModel
    {
        private Player selectedPlayer;
        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value; OnPropertyChanged(); } }
        public ObservableCollection<Player> Players { get; set; }//אוסף שחקנים
        private bool isRefreshing;
        public bool IsRefreshing { get => IsRefreshing; set { IsRefreshing = value; OnPropertyChanged(); } } 

        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        //צריך להוסיף פעולות

        public UserAdminPageViewModel()
        {
            Players = new ObservableCollection<Player>();

            RefreshCommand = new Command(async () => await Refresh());
            DeleteCommand = new Command(() => Delete());
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

        private void Delete()
        {
            if(SelectedPlayer!= null)
            {
                Players.Remove(SelectedPlayer);
                SelectedPlayer = null;
            }

        }
 

    }
}
