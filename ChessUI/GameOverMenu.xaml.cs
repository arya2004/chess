using ChessLogic;
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

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        
        public GameOverMenu(GameState game)
        {
            InitializeComponent();
            Result result = game.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, game.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner) => winner switch
        {
            Player.White => "WHITE WON!",
            Player.Black => "BLACK WON!",
            _ => "DRAW ;("
        };

        private static string PlayerString(Player player) => player switch
        {
            Player.White => "WHITE",
            Player.Black => "BLACK",
            _ => ""
        };

        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate => $"StaleMate - {PlayerString(currentPlayer)} can't move",
                EndReason.Checkmate => $"checkMate - {PlayerString(currentPlayer)} can't move",
                EndReason.FiftyMoveRule => $"FiftyMove Rule",
                EndReason.InsufficientMaterial => $"Insufficient Material",
                EndReason.ThreefoldRepetition => $"Threefold Repetition",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
