using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Bim494_Hw1
{
    public partial class App : Application
    {

        public static UserRepository UserRepo { get; private set; }


        public App(string dbPath)
        {
            InitializeComponent();

            UserRepo = new UserRepository(dbPath);

            MainPage = new NavigationPage(new FirstScreen());

           //MainPage = new ConfigPage();

#if DEBUG
            LiveReload.Init();
#endif
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
