using System;
using TabbedMP.Services;
using TabbedMP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMP
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
