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

namespace MVVMPrroyecto 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAgregarDinosaurio_Click(object sender, RoutedEventArgs e)
        {

            string dinosaurio = txtdinosaurio.Text;

            ListBoxItem nuevoDinosaurio = new ListBoxItem();
            nuevoDinosaurio.Content = dinosaurio;

            lstDinosaurios.Items.Add(nuevoDinosaurio);

            txtdinosaurio.Text = "";   

             
        }

        private void btnEliminarDinosaurio_Click(object sender, RoutedEventArgs e)
        {
            

            lstDinosaurios.Items.Remove(lstDinosaurios.SelectedItem);   

        }
    }
}
