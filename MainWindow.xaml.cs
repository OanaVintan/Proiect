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


namespace Proiect
{

    public partial class MainWindow : Window
    {
        private int mTipRoșuSec = 30;
        private int mTipRoșuDemisec = 45;
        private int mTipRoșuDemidulce = 60;
        private int mTipAlbSec = 35;
        private int mTipAlbDemisec = 40;
        private int mTipAlbDemidulce = 55;
        private int mTipRoseDemidulce = 70;
        private double Total = 0;
        private VinuriType selectedVinuri;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sec1MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipRoșuSec++;
            txtSec1.Text = mTipRoșuSec.ToString();
        }
        private void demisec1MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipRoșuDemisec++;
            txtDemisec1.Text = mTipRoșuDemisec.ToString();
        }

        private void demidulce1MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipRoșuDemidulce++;
            txtDemidulce1.Text = mTipRoșuDemidulce.ToString();

        }

        private void sec2MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipAlbSec++;
            txtSec2.Text = mTipAlbSec.ToString();

        }

        private void demisec2MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipAlbDemisec++;
            txtDemisec2.Text = mTipAlbDemisec.ToString();
        }

        private void demidulce2MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipAlbDemidulce++;
            txtDemidulce2.Text = mTipAlbDemidulce.ToString();
        }

        private void demidulce3MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mTipRoseDemidulce++;
            txtDemidulce3.Text = mTipRoseDemidulce.ToString();
        }
        private void FilledItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " - Se pregătește vinul!";
            this.Title = mesaj;
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        KeyValuePair<VinuriType, double>[] PriceList = {
            new KeyValuePair<VinuriType, double>(VinuriType.RosuSec, 32),
            new KeyValuePair<VinuriType, double>(VinuriType.RosuDemisec, 35),
            new KeyValuePair<VinuriType, double>(VinuriType.RosuDemidulce, 30),
            new KeyValuePair<VinuriType, double>(VinuriType.AlbSec, 32),
            new KeyValuePair<VinuriType, double>(VinuriType.AlbDemisec, 35),
            new KeyValuePair<VinuriType, double>(VinuriType.AlbDemidulce, 30),
            new KeyValuePair<VinuriType, double>(VinuriType.RoseDemidulce, 35)
              };

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbTip.ItemsSource = PriceList;
            cmbTip.DisplayMemberPath = "Key";
            cmbTip.SelectedValuePath = "Value";
        }
        private void cmbTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPreț.Text = cmbTip.SelectedValue.ToString();
            KeyValuePair<VinuriType, double> selectedEntry =
           (KeyValuePair<VinuriType, double>)cmbTip.SelectedItem;
            selectedVinuri = selectedEntry.Key;
        }
        private int ValidateQuantity(VinuriType selectedVinuri)
        {
            int q = int.Parse(txtCantitate.Text);
            int r = 1;

            switch (selectedVinuri)
            {
                case VinuriType.RosuSec:
                    if (q > mTipRoșuSec)
                        r = 0;
                    break;
                case VinuriType.RosuDemisec:
                    if (q > mTipRoșuDemisec)
                        r = 0;
                    break;
                case VinuriType.RosuDemidulce:
                    if (q > mTipRoșuDemidulce)
                        r = 0;
                    break;
                case VinuriType.AlbSec:
                    if (q > mTipAlbSec)
                        r = 0;
                    break;
                case VinuriType.AlbDemisec:
                    if (q > mTipAlbDemisec)
                        r = 0;
                    break;
                case VinuriType.AlbDemidulce:
                    if (q > mTipAlbDemidulce)
                        r = 0;
                    break;
                case VinuriType.RoseDemidulce:
                    if (q > mTipRoseDemidulce)
                        r = 0;
                    break;
            }
            return r;
        }
        private void btnAdaugă_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedVinuri) > 0)
            {
                lstComandă.Items.Add(txtCantitate.Text + " - " + selectedVinuri.ToString() +
               ":" + txtPreț.Text + "  " + double.Parse(txtCantitate.Text) * double.Parse(txtPreț.Text));
                Total = Total + double.Parse(txtCantitate.Text) * double.Parse(txtPreț.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }
        private void btnȘterge_Click(object sender, RoutedEventArgs e)
        {
            lstComandă.Items.Remove(lstComandă.SelectedItem);
        }

        private void btnTrimite_Click(object sender, RoutedEventArgs e)
        {
            {
                txtTotal.Text = "0";
                foreach (string s in lstComandă.Items)
                {
                    switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") - 1))
                    {
                        case "RoșuSec":
                            mTipRoșuSec = mTipRoșuSec - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtSec1.Text = mTipRoșuSec.ToString();
                            break;
                        case "RoșuDemisec":
                            mTipRoșuDemisec = mTipRoșuDemisec - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtDemisec1.Text = mTipRoșuDemisec.ToString();
                            break;
                        case "RoșuDemidulce":
                            mTipRoșuDemidulce = mTipRoșuDemidulce - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtDemidulce1.Text = mTipRoșuDemidulce.ToString();
                            break;
                        case "AlbSec":
                            mTipAlbSec = mTipAlbSec - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtSec2.Text = mTipAlbSec.ToString();
                            break;
                        case "AlbDemisec":
                            mTipAlbDemisec = mTipAlbDemisec - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtDemisec2.Text = mTipAlbDemisec.ToString();
                            break;
                        case "AlbDemidulce":
                            mTipAlbDemidulce = mTipAlbDemidulce - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtDemidulce2.Text = mTipAlbDemidulce.ToString();
                            break;
                        case "RoseDemidulce":
                            mTipRoseDemidulce = mTipRoseDemidulce - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                            txtDemidulce3.Text = mTipRoseDemidulce.ToString();
                            break;
                    }
                }
                lstComandă.Items.Clear();
            }

        }
        private void txtCantitate_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void frmMain_Loaded_1(object sender, RoutedEventArgs e)
        {
            cmbTip.ItemsSource = PriceList;
            cmbTip.DisplayMemberPath = "Key";
            cmbTip.SelectedValuePath = "Value";
        }
    }
}
