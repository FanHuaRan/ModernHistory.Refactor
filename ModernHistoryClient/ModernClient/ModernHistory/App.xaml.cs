using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 [assembly: log4net.Config.XmlConfigurator(Watch = true)] 
namespace ModernHistory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ILog logger = LogManager.GetLogger(typeof(App));
        protected override void OnStartup(StartupEventArgs e)
        {
            //未知异常记录日志
            this.DispatcherUnhandledException += (sender, e1) =>
            {
                //logger.Error("未知异常", e1.Exception);
                e1.Handled = true;
            };
        }
    }
}
