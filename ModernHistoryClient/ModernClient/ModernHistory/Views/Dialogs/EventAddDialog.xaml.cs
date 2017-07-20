using FirstFloor.ModernUI.Windows.Controls;
using ModernHistory.ViewModels;
using System;
using System.Collections.Generic;
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

namespace ModernHistory.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for EventAddDialog.xaml
    /// </summary>
    public partial class EventAddDialog : ModernDialog
    {
        public EventAddDialog(EventAddDialogViewModel eventAddDialogViewModel)
        {
            InitializeComponent();
            eventAddDialogViewModel.Dialog = this;
            this.DataContext = eventAddDialogViewModel;
            CloseButton.Visibility = Visibility.Hidden;
        }
    }
}
