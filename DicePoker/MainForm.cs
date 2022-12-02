using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DicePoker
{
    public partial class MainForm : Form
    {
        private DicePokerGame game;
        private readonly CheckBox[] checkBoxes;

        public MainForm()
        {
            InitializeComponent();
            checkBoxes = new[] { chkKeep1, chkKeep2, chkKeep3, chkKeep4, chkKeep5 };

            StartNewGame();
        }

        private void BtnRoll_Click(object sender, EventArgs e)
        {
            if (game.IsStarted && game.CurrentPlayer.NumberOfReRolls > 0)
            {
                ReRoll();
            }
            else
            {
                Roll();
            }
        }

        private void Roll()
        {
            try
            {
                if (game == null)
                {
                    throw new InvalidOperationException("Start a new game.");
                }

                List<byte> result;
                if (!game.IsStarted)
                {
                    var players = ShowPlayersForm();
                    result = game.Start(players);
                }
                else
                {
                    result = game.ChangeTurn();
                }
                AfterStartOperations(result);
            }
            catch (Exception ex)
            {
                ShowErroBox(ex);
            }
        }

        private void AfterStartOperations(List<byte> result)
        {
            lblCurrentPlayer.Text = game.CurrentPlayer.DisplayName;
            AddListViewItemToListView(result.ToListViewItem(game.CurrentPlayer, String.Empty));

            foreach (var checkBox in checkBoxes)
            {
                checkBox.Checked = false;
            }

            btnRoll.Text = "Re-roll";
            btnPokerHand.Enabled = true;

            cbPokerHands.DataSource = game.CurrentPlayer.GetNotSetPokerHandTypes();
            cbPokerHands.SelectedIndex = 0;
        }

        private List<Player> GetDefaultPlayers()
        {
            return new List<Player>
            {
                new Player("Player 1", PlayerType.Human, game.Dice),
                new ComputerPlayer("Computer 1", game.Dice),
                new ComputerPlayer("Computer 2", game.Dice)
            };
        }

        private List<Player> ShowPlayersForm()
        {
            var playersForm = new PlayersForm(game.Dice);
            if (playersForm.ShowDialog() == DialogResult.OK)
            {
                return playersForm.Players;
            }
            return GetDefaultPlayers();
        }
 
        private void ReRoll()
        {
            try
            {
                var notKeptIndexes = checkBoxes.Where(cb => !cb.Checked).Select(cb => (byte)(cb.Name.Last() - '1'));
                
                var result = game.ReRoll(notKeptIndexes.ToArray());
                lvRolls.Items.RemoveAt(lvRolls.Items.Count - 1);
                AddListViewItemToListView(result.ToListViewItem(game.CurrentPlayer, String.Empty));

                btnRoll.Enabled = game.CurrentPlayer.NumberOfReRolls > 0;
            }
            catch (Exception ex)
            {
                ShowErroBox(ex);
            }
        }

        private void AddListViewItemToListView(ListViewItem item)
        {
            item.BackColor = lvRolls.Items.Count % 2 == 0 ? Color.LightBlue : lvRolls.BackColor;
            lvRolls.Items.Add(item);
            item.EnsureVisible();
        }

        private static void ShowErroBox(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TsmiNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            lvRolls.Items.Clear();
            game = new DicePokerGame();
        }

        private void BtnPokerHand_Click(object sender, EventArgs e)
        {
            var pokerHandResult = new PokerHandResult
            {
                PokerHandType = (PokerHandType)cbPokerHands.SelectedItem,
                Values = game.LastRollResult
            };
            game.CurrentPlayer.Set(pokerHandResult);

            btnRoll.Enabled = true;
            btnRoll.Text = "Roll";
            btnPokerHand.Enabled = false;
            var lastItem = lvRolls.Items[lvRolls.Items.Count - 1];
            lastItem.SubItems[lastItem.SubItems.Count - 2].Text = pokerHandResult.PokerHandType.ToString();
            lastItem.SubItems[lastItem.SubItems.Count - 1].Text = game.CurrentPlayer.PokerHands.Points.ToString();

            var computerResults = game.CheckComputerPlayersTurn();
            foreach (var computerResult in computerResults)
            {
                lblCurrentPlayer.Text = computerResult.Player.DisplayName;
                AddListViewItemToListView(computerResult.Values.ToListViewItem(computerResult.Player, computerResult.PokerHandType.ToString()));
            }
            lblCurrentPlayer.Text = game.NextPlayer.DisplayName;
        }

        private void TsmiChangePlayers_Click(object sender, EventArgs e)
        {
            var playersForm = new PlayersForm(game.Dice);
            if (playersForm.ShowDialog() == DialogResult.OK)
            {
                lvRolls.Items.Clear();
                var result = game.Start(playersForm.Players);
                AfterStartOperations(result);
            }
        }
    }
}
