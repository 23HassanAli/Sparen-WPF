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

namespace Sparen
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

        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                double weekGeld = double.Parse(txbxWeekgeld.Text);
                double wekelijkseVerhoging = double.Parse(txbxWeekVerhoging.Text);
                double gewensteBedrag = double.Parse(txbxSpaarBedrag.Text);
                double aantalWeken = HoeveelWeken(weekGeld, wekelijkseVerhoging, gewensteBedrag);
                double spaarBedrag = SpaarBedrag(aantalWeken, weekGeld);
                double geldMetVerhoging = weekGeld + wekelijkseVerhoging;
                double totaalGeld = TotaalGeld(geldMetVerhoging, aantalWeken);
                double extraGeld = Math.Round(ExtraGeld(totaalGeld, spaarBedrag), 2);

                sb.AppendLine("Spaarbedrag na " + aantalWeken + " weken: € " + spaarBedrag);
                sb.AppendLine("Extra weekgeld op dat moment: € " + extraGeld);
                sb.AppendLine("Totaal spaargeld: € " + totaalGeld);
                txblResultaat.Text = sb.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong!", "Error");
            }
          
        }
        private double ExtraGeld(double totaalGeld, double spaarBedrag)
        {
            double extraGeld = totaalGeld - spaarBedrag;
            return extraGeld;
        }
        private double TotaalGeld(double geldMetVerhoging, double aantalWeken)
        {
            double totaalGeld = geldMetVerhoging * aantalWeken;
            return totaalGeld;
        }
        private double SpaarBedrag(double weken, double weekgeld)
        {
            double spaarBedrag = weken * weekgeld;
            return spaarBedrag;
        }
        private double HoeveelWeken(double weekgeld, double verhoging, double spaarBedrag)
        {
            double aantalWeken = Math.Ceiling(spaarBedrag / (weekgeld + verhoging));
            return aantalWeken;
        }
    }
}
