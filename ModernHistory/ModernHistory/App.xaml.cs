using ModernHistory.Services;
using ModernHistory.Services.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ModernHistory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IFamousePersonService personService = new FamousePersonServiceClass();
            personService.FindAllAsync();
        }
    }
}
