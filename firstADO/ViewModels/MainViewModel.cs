using firstADO.Commands;
using firstADO.Models;
using System.Windows.Input;

namespace firstADO.ViewModels;



public class MainViewModel : NotifyService
{
    string connectionString = "Data Source=COMPUTER01\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True";
    string? _username;
    string? _password;
    string? _errorLogin;

    public string? Username { get => _username; set { _username = value; OnPropertyChange(); } }
    public string? Password { get => _password; set { _password = value; OnPropertyChange(); } }
    public string? ErrorLogin { get => _errorLogin; set { _errorLogin = value; OnPropertyChange(); } }
    public ICommand LoginCommand { get; set; }
    public ICommand SignUpCommand { get; set; }
    public MainViewModel()
    {
        LoginCommand = new RelayCommand(LoginExecute);
        SignUpCommand = new RelayCommand(SignUpExecute);
    }
    public void SignUpExecute(object? obj)
    {
        App.Container.GetInstance<MainWindow>().Hide();

        ////var view = App.Container.GetInstance<SignUpWindow>();
        //view.DataContext = App.Container.GetInstance<SignUpViewModel>();
        //view.Show();
    }
    public void LoginExecute(object? obj)
    {


    }
}
