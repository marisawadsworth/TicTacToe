using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TikTacToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        // Takes you to the TicTacToe Game
        private void Button_Click_Play(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        // Takes you to the Rules page
        private void Button_Click_Rules(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }

        // Takes you to the Classes page
        private void Button_Click_Classes(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Class));
        }

        private async void Debug_Click(object sender, RoutedEventArgs e)
        {
            DebugUtils.MessageBox("Message");

            int test = await DebugUtils.MessageBox("Message", "Title");
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            //SolidColorBrush Background = new SolidColorBrush(Colors.Red);
            //play.Background = new SolidColorBrush(Colors.Red); 

            //rules.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(58, 58, 58, 0));
            //classes.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(58, 58, 58, 0));
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
        //    //SolidColorBrush Background = new SolidColorBrush(Colors.Red);
        //    //play.Background = Background;

        //    //play.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(58, 58, 58, 15));
        //    //rules.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(58, 58, 58, 15));
        //    //classes.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(58, 58, 58, 15));]
        }

        private void button_PointerEntered_1(object sender, PointerRoutedEventArgs e)
        {
            button.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(20, 200, 70, 55));
        }

        private void button_PointerExited_1(object sender, PointerRoutedEventArgs e)
        {
            button.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 12, 120, 50));
        }
    }
}
