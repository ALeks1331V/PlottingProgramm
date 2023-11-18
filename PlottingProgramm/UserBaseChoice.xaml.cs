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
using Lsj.Util.Win32.Enums;
using PlottingProgramm.ViewModel;
using ScottPlot;
using ScottPlot.Plottable;

namespace PlottingProgramm
{
    /// <summary>
    /// Interaction logic for UserBaseChoice.xaml
    /// </summary>
    public partial class UserBaseChoice : Page
    {
        public UserBaseChoice()
        {
            InitializeComponent();
        }

        private void cmbbButtonClick(object sender, RoutedEventArgs e)
        {
            if (ComboboxGrid.Visibility==Visibility.Hidden)
                ComboboxGrid.Visibility=Visibility.Visible;
            else ComboboxGrid.Visibility=Visibility.Hidden;
        }

        private void MoneyOnBalanceButtonClick(object sender, RoutedEventArgs e)
        {
            WpfPlot.Reset();
            VM getDataFromDB = new VM("ClientInfoBank", "months", "MoneyOnClientsBalance", 12);
            ComboboxGrid.Visibility = Visibility.Hidden;
            double[] dataY = getDataFromDB.array2;
            double[] dataX = getDataFromDB.array;
            WpfPlot.Plot.AddBar(dataY, dataX);
            WpfPlot.Plot.SetAxisLimits(yMin: 0);
            WpfPlot.Plot.AddAnnotation("Money on Clients Balance (Bar Graph)");
            WpfPlot.Refresh();
        }

        private void yourDeptButtonClick(object sender, RoutedEventArgs e)
        {
            WpfPlot.Reset();
            VM getDataFromDB = new VM("ClientInfoBank", "months", "ClientsDept", 12);
            ComboboxGrid.Visibility = Visibility.Hidden;
            double[] dataX = getDataFromDB.array;
            double[] dataY = getDataFromDB.array2;
            WpfPlot.Plot.AddScatter(dataX, dataY);
            WpfPlot.Plot.AddAnnotation("Clients Dept Graph (Simple)");
            WpfPlot.Refresh();
        }
        private void ClientSavingsButtonClick(object sender, RoutedEventArgs e)
        {
            WpfPlot.Reset();
            VM getDataFromDB = new VM("ClientInfoBank", "months", "YourSavings", 12);
            ComboboxGrid.Visibility = Visibility.Hidden;
            double[] dataX = getDataFromDB.array;
            double[] dataY = getDataFromDB.array2;
            WpfPlot.Plot.AddScatter(dataX, dataY);
            WpfPlot.Plot.AddAnnotation("Clients Savings Graph (Simple)");
            WpfPlot.Refresh();
        }

        private void BankInfoButtonClick(object sender, RoutedEventArgs e)
        {
            WpfPlot.Reset();
            VM getDataFromDB = new VM("BankInfo", "Amount", "Parameter", 3);
            ComboboxGrid.Visibility = Visibility.Hidden;
            double[] values = getDataFromDB.array;
            string[] labels = getDataFromDB.arrayStr;
            var pie = WpfPlot.Plot.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowPercentages = true;
            pie.ShowValues = true;
            pie.ShowLabels = true;
            WpfPlot.Plot.Legend();
            WpfPlot.Refresh();
        }

        private void RadarGraphButtonClick(object sender, RoutedEventArgs e)
        {
            WpfPlot.Reset();
            VM getDataFromDB = new VM("ComplianceWithThePlanTable", "ThisYear", "LastYear", "Parametr", 3);
            ComboboxGrid.Visibility = Visibility.Hidden;
            double[] a = getDataFromDB.array;
            double[] b = getDataFromDB.array2;
            double[,] values = new double[2, 3];
            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    values[i, j] = new double[][] { a, b }[i][j];
                }
            }
            var radar = WpfPlot.Plot.AddRadar(values);
            radar.AxisType = RadarAxis.Polygon;
            string[] strArray = getDataFromDB.arrayStr2;
            radar.CategoryLabels = strArray;
            WpfPlot.Refresh();
        }
    }
}
