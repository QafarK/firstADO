using firstADO.Commands;
using firstADO.Models;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace firstADO.ViewModels;

public class SignUpViewModel : NotifyService
{
    string? _name;
    string? _surname;
    int? _age;
    string? _login;
    string? _password;
    string? _confirmpassword;

    public string? Name { get => _name; set { _name = value; OnPropertyChange(); } }
    public string? Surname { get => _surname; set { _surname = value; OnPropertyChange(); } }
    public int? Age { get => _age; set { _age = value; OnPropertyChange(); } }
    public string? Login { get => _login; set { _login = value; OnPropertyChange(); } }
    public string? Password { get => _password; set { _password = value; OnPropertyChange(); } }
    public string? ConfirmPassword { get => _confirmpassword; set { _confirmpassword = value; OnPropertyChange(); } }
    public ICommand SignUpCommand { get; set; }

    public SignUpViewModel()
    {
        SignUpCommand = new RelayCommand(SignUpExecute, CanSignUp);
    }

    private bool CanSignUp(object? obj)
    {
        if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) && Age > 0
            && !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword) && Password.Equals(ConfirmPassword))
            return true;
        return false;
    }

    public void SignUpExecute(object? obj)
    {
        string connectionString = "Data Source=COMPUTER01\\SQLEXPRESS;Initial Catalog=Loginer;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertQuery = new(
                @$"INSERT INTO LoginAccount(Name_,Surname,Age,Login_,Password_)
                  VALUES('{Name}','{Surname}','{Age}','{Login}','{Password}');");

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = insertQuery;
            cmd.ExecuteNonQuery();
        }
    }
}