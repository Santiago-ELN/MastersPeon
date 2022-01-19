using MastersPeon.Services;
using MastersPeon.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MastersPeon
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DBService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
