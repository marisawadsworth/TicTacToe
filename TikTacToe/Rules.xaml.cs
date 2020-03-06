using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.SpeechSynthesis;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TikTacToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Rules : Page
    {
        // Provides access to the speech synthesis engine(voice) for Text-to-speech
        SpeechSynthesizer reader;
        public Rules()
        {
            this.InitializeComponent();
            // Configure the audio output.
            reader = new SpeechSynthesizer();

           
        }

        private void Button_Click_Speak(object sender, RoutedEventArgs e)
        {
            // Talk the text
            Talk(Speak_Block.Text);
        }

        /// <summary>
        /// Plays a text to talk
        /// </summary>
        /// <param name="message">Our message to talk</param>
        private async void Talk(string message)
        {
            // Get the text
            var stream = await reader.SynthesizeTextToStreamAsync(message);
            // Setup the stream for the player
            media.SetSource(stream, stream.ContentType);
            // Play the message
            media.Play();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StartPage));
        }

    }
}
