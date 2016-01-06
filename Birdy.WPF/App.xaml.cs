namespace Birdy
{
    using System.Windows;
    using Birdy.Data.ViewModels.Navigation;
    using Birdy.WPF.Views;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Shell app = new Shell();
            ApplicationViewModel context = new ApplicationViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
