using HomeStyler.Pages;

namespace HomeStyler
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell
            {
                CurrentItem = new FlyoutItem
                {
                    Title = "LoginPage",
                    Items = { new ShellContent { ContentTemplate = new DataTemplate(typeof(LoginPage)) } }
                }
            };
        }
    }
}