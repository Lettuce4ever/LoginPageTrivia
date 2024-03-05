
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginPage.Models;
using LoginPage.Service;

namespace LoginPage.ViewModels
{
    public class LoginPageViewModel: ViewModel
    {
        private string name;
        private string password;
        private Color color;
        private string labletext;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); } }
        public string LabelText { get { return labletext; } set { labletext = value; OnPropertyChanged(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged();((Command)LoginCommand).ChangeCanExecute(); } }
        public Color Color { get { return color; } set { color = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(SearchUserByCommand);
            CancelCommand = new Command(CancelAll);
        }

        public void SearchUserByCommand()
        {

            Color = Colors.Red;
            UserService service = new UserService();
            bool isSuc = service.LoginSuc(new Player() { PlayerName = this.Name, PlayerPass = this.Password });
            
            //אם הצלחתי להץתחבר
            if (isSuc&& isSuc!=null)
            {
                Color = Colors.Green;
                LabelText = "Login Succeeded!";
            }
            else 
            {
                Color = Colors.Red;
                LabelText = "Login Failed!";
            }
            Reset();
          
        }
        public void CancelAll()
        {
            Reset();
        }
        private void Reset()
        {
            Password = null;
            Name = null;
        }
      
    }
}
