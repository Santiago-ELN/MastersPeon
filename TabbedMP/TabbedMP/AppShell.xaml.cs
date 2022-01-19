using System;
using System.Collections.Generic;
using TabbedMP.ViewModels;
using TabbedMP.Views;
using Xamarin.Forms;

namespace TabbedMP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TablesPage), typeof(TablesPage));
            Routing.RegisterRoute(nameof(NewTablePage), typeof(NewTablePage));
        }

    }
}
