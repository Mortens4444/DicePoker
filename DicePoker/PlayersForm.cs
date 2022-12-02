using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DicePoker
{
    public partial class PlayersForm : Form
    {
        public List<Player> Players { get; private set; }

        private readonly DiceCollection dice;

        public PlayersForm(DiceCollection dice)
        {
            InitializeComponent();
            this.dice = dice;
            cbPlayerType.DataSource = Enum.GetValues(typeof(PlayerType));
            cbPlayerType.SelectedIndex = 0;
            SetButtonsState();
            Players = new List<Player>();
        }

        private void TsmiDelete_Click(object sender, EventArgs e)
        {
            if (lvPlayers.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete selected users?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    for (int i = lvPlayers.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lvPlayers.Items.Remove(lvPlayers.SelectedItems[i]);
                    }
                    SetButtonsState();
                }
            }
        }

        private void SetButtonsState()
        {
            btnStart.Enabled = lvPlayers.Items.Count > 1;
            btnAdd.Enabled = lvPlayers.Items.Cast<ListViewItem>().All(item => item.Text != tbPlayerName.Text);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var item = new ListViewItem(tbPlayerName.Text);
            item.SubItems.Add(cbPlayerType.Text);
            item.Tag = cbPlayerType.SelectedItem;
            lvPlayers.Items.Add(item);
            tbPlayerName.Text = String.Empty;
            SetButtonsState();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

            for (byte i = 0; i < lvPlayers.Items.Count; i++)
            {
                var item = lvPlayers.Items[i];
                var playerType = (PlayerType)item.Tag;
                var player = playerType == PlayerType.Human ?
                    new Player(item.Text, playerType, dice) :
                    new ComputerPlayer(item.Text, dice);
                Players.Add(player);
            }
        }

        private void TbPlayerName_TextChanged(object sender, EventArgs e)
        {
            SetButtonsState();
        }
    }
}
