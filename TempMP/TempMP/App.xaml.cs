using System;
using TempMP.Services;
using TempMP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempMP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
