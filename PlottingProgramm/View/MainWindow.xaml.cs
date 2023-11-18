using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using PlottingProgramm.View;
using ScottPlot;
using Walterlv.Demo.Interop;

namespace PlottingProgramm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowBlur.SetIsEnabled(this, true);
        }

        private void BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimizeClick(object sender, RoutedEventArgs e)
        {
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        }
        private void ButtonShutDownClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void pageHowItWorksClick(object sender, RoutedEventArgs e)
        {
            ChangingFrame.Content = new HowItWorks();
        }
        private void pageGitHub(object sender, RoutedEventArgs e)
        {
            ChangingFrame.Content = new CheckMyGitHub();
        }

        private void pageCalculate(object sender, RoutedEventArgs e)
        {
            ChangingFrame.Content = new UserBaseChoice();
        }

        private void pageSettingsClick(object sender, RoutedEventArgs e)
        {
            ChangingFrame.Content = new SettingsPage();
        }

    }
}
