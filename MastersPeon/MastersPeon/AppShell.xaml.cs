using MastersPeon.ViewModels;
using MastersPeon.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MastersPeon
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TableDetailsPage), typeof(TableDetailsPage));
            Routing.RegisterRoute(nameof(AddTablePage), typeof(AddTablePage));
        }

    }
}
