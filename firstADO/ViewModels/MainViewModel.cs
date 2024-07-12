using firstADO.Commands;
using firstADO.Models;
using firstADO.Views;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Input;

namespace firstADO.ViewModels;



public class MainViewModel : NotifyService
{
    string connectionString = "Data Source=COMPUTER01\\SQLEXPRESS;Initial Catalog=Loginer;Integrated Security=True;TrustServerCertificate=True";
    string? _username;
    string? _password;
    string? _errorLogin;
    SqlDataReader? reader = null;

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
    public void LoginExecute(object? obj)
    {
        try
        {

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new();

                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM LoginAccount";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[3].Equals(Username) && reader[4].Equals(Password))
                    {
                        MessageBox.Show($"Welcome {reader[0]} {reader[1]} !");
                        break;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    public void SignUpExecute(object? obj)
    {
        App.Container.GetInstance<MainWindow>().Hide();

        var view = App.Container.GetInstance<SignUpWindow>();
        view.DataContext = App.Container.GetInstance<SignUpViewModel>();
        view.Show();
    }
}
