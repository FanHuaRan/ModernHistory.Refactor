using FirstFloor.ModernUI.Windows.Controls;
using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernHistory.Views.Event
{
    /// <summary>
    /// Interaction logic for SelectPersonDialog.xaml
    /// </summary>
    public partial class SelectPersonsDialog : ModernDialog
    {
        public SelectPersonsDialog()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }
    }
}
