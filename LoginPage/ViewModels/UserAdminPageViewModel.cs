
using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPage.Service;
using System.Collections.ObjectModel;

using System.Windows.Input;


namespace LoginPage.ViewModels
{
    public class UserAdminPageViewModel : ViewModel
    {
       
        private Player selectedPlayer;
        private bool isRefreshing;
        private UserService service;

        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value; OnPropertyChanged(); } }
        public ObservableCollection<Player> Players { get; set; }//אוסף שחקנים
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        //צריך להוסיף פעולות

        public UserAdminPageViewModel(UserService service)
        {
            this.service= service;
            Players = new ObservableCollection<Player>();

            RefreshCommand = new Command(async () => await Refresh());
            DeleteCommand = new Command<Player>(async(p) => await Delete(p));
            //LoadPlayers();
        }

        private async Task LoadPlayers()
        {
            Players.Clear();
            foreach (var player in service.playersList)
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

        private async Task Delete(Player p)
        {
            if(p!= null)
            {
                Players.Remove(p);
                SelectedPlayer = null;
            }

        }
 

    }
}
