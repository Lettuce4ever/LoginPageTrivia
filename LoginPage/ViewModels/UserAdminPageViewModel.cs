
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
        private List<Player> fullList;
        private List<Player> filteredList;
        private bool isRefreshing;
        private UserService service;
        private int selectedIndex;
        private Darga selectedDarga;
        private RankService rankService;

        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value; OnPropertyChanged(); } }
        public ObservableCollection<Player> Players { get; set; }//אוסף שחקנים
        public ObservableCollection<Darga> Dargas { get; set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public Darga SelectedDarga { get => selectedDarga; set { if (selectedDarga != value) { OnPropertyChanged(); FilterPlayers(); } } }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }

        //צריך להוסיף פעולות

        public UserAdminPageViewModel(UserService service, RankService Rservice)
        {
            this.rankService= Rservice;
            fullList= new List<Player>();
            this.service= service;
            Players = new ObservableCollection<Player>();
            Dargas =new ObservableCollection<Darga>();

            FilterCommand = new Command(async () => await FilterPlayers());
            ClearFilterCommand = new Command(async () => await LoadPlayers());
            RefreshCommand = new Command(async () => await Refresh());
            DeleteCommand = new Command<Player>(async(p) => await Delete(p));
            
            var Darga = rankService.Dargas;
            Dargas.Clear();
            foreach (var darga in Darga)
            {
                Dargas.Add(darga);
            }
        }

        private async Task LoadPlayers()
        {

            
            fullList = service.GetPlayers();
            Players.Clear();
            foreach (var player in fullList)
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

        private async Task FilterPlayers()
        {
            filteredList = fullList.Where(Player => Player.Darga.DargaId==(int)SelectedIndex).ToList();
            await Task.Delay(1000);
            Players.Clear();
            foreach (var player in filteredList)
            {
                Players.Add(player);
            }
            SelectedIndex = -1;
        }
 

    }
}
