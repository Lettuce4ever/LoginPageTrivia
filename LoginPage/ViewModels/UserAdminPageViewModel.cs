using AndroidX.Lifecycle;
using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPage.Service;
using System.Collections.ObjectModel;


namespace LoginPage.ViewModels
{
    public class UserAdminPageViewModel:ViewModel
    {
        public ObservableCollection<Player> Players { get; set; }//אוסף שחקנים

        //צריך להוסיף פעולות

        public UserAdminPageViewModel() 
        {
            Players = new ObservableCollection<Player>();
            
        }

    }
}
