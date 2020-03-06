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
using Windows.Media;
using Windows.UI;
using Windows.Media.SpeechSynthesis;
using System.Diagnostics;

namespace TikTacToe

{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
            // Provides access to the speech synthesis engine (voice) for Text-to-speech 
            SpeechSynthesizer reader;

        #region Private Members

        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (x) or player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            NewGame();

            //Speech
            this.InitializeComponent();
            // Configure the audio output.
            reader = new SpeechSynthesizer();
        }

        #endregion

        /// <summary>
        /// Starts a new game and clears all values back to start
        /// </summary>
        private void NewGame()
        {
            //Creates a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;


            //Make sure player 1 starts the game
            mPlayer1Turn = true;


            //Interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //Change background, foreground, and content to default values
                button.Content = string.Empty;

                SolidColorBrush Background = new SolidColorBrush(Colors.White);
                button.Background = Background;

                SolidColorBrush Foreground = new SolidColorBrush(Colors.Blue);
                button.Foreground = Foreground;
            });

            //Make sure the game hasn't finished
            mGameEnded = false;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            // Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);
            
            //Don't do anything if the cell aready has a value in it
            if (mResults[index] != MarkType.Free)
                return;

            //Set the cell value based on which players turn it is
            if (mPlayer1Turn)
                mResults[index] = MarkType.Cross;
            else
                mResults[index] = MarkType.Nought;

            // Another way of writing an if else.
            //mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Set the button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            // Change nought to red
            if (!mPlayer1Turn)
            {
                SolidColorBrush Foreground = new SolidColorBrush(Colors.Red);
                button.Foreground = Foreground;
            }

            // Inverts a value. If its true it becames false. If its false it becames true.
            mPlayer1Turn ^= true;

            //Check for winner
            CheckForWinner();
        }

        /// <summary>
        /// Check if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal Wins
            //Check for horizontal wins
            //
            // - Row 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button0_0.Background = Button1_0.Background = Button2_0.Background = WinBackground;
            }
            //
            // - Row 1
            //
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button0_1.Background = Button1_1.Background = Button2_1.Background = WinBackground;
            }
            //
            // - Row 2
            //
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button0_2.Background = Button1_2.Background = Button2_2.Background = WinBackground;
            }
            #endregion

            #region Vertical Wins
            //Check for vertical wins
            //
            // - Column 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button0_0.Background = Button0_1.Background = Button0_2.Background = WinBackground;
            }
            //
            // - Column 1
            //
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button1_0.Background = Button1_1.Background = Button1_2.Background = WinBackground;
            }
            //
            // - Column 2
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button2_0.Background = Button2_1.Background = Button2_2.Background = WinBackground;
            }
            #endregion

            #region Diagonal Wins

            //Check for diagonal wins
            //
            // - Top left Bottom Right
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button0_0.Background = Button1_1.Background = Button2_2.Background = WinBackground;
            }
            //
            // - Top Right Bottom Left
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // Game ends
                mGameEnded = true;

                //Highlight winning cells in yellow
                SolidColorBrush WinBackground = new SolidColorBrush(Colors.Yellow);
                Button2_0.Background = Button1_1.Background = Button0_2.Background = WinBackground;
            }


            #endregion

            #region No Winners
            //Check for no winner and full board
            if (!mResults.Any(result => result == MarkType.Free))
            {
                //Game ended
                mGameEnded = true;

                //Turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    SolidColorBrush Background = new SolidColorBrush(Colors.Orange);
                    button.Background = Background;
                });
            }
            #endregion
        }

    }
}
