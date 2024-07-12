using System.Windows;
using firstADO.ViewModels;
using firstADO.Views;
using SimpleInjector;
namespace firstADO
{
    public partial class App : Application
    {
        public static Container Container { get; set; } = new Container();
        public App()
        {
            Registers();
        }

        private void Registers()
        {
            Container.RegisterSingleton<MainWindow>();
            Container.RegisterSingleton<MainViewModel>();

            Container.RegisterSingleton<SignUpWindow>();
            Container.RegisterSingleton<SignUpViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var view = Container.GetInstance<MainWindow>();
            view.DataContext = Container.GetInstance<MainViewModel>();

            view.Show();

            base.OnStartup(e);
        }
    }

}
