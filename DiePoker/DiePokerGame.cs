using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DiePoker
{
    public class DiePokerGame
    {
        public bool IsStarted { get; private set; }

        public List<byte> LastRollResult { get; private set; }

        public List<Player> Players { get; private set; }

        public DieCollection Dies { get; private set; }

        public Player CurrentPlayer
        {
            get
            {
                return Players[playerIndex];
            }
        }

        public Player NextPlayer
        {
            get
            {
                return Players[GetNextPlayerIndex()];
            }
        }

        private byte playerIndex;
        private byte currentNumberOfRolls;
        private readonly int MaximumNumberOfRolls = Enum.GetValues(typeof(PokerHandType)).Length;

        public DiePokerGame()
        {
            Dies = DieCollectionFactory.CreateDiePoker();
            IsStarted = false;
        }

        public List<byte> ChangeTurn()
        {
            CheckGameState();
            playerIndex++;
            if (playerIndex == Players.Count)
            {
                SetDefaultPlayerIndex();
                currentNumberOfRolls++;
	            if (currentNumberOfRolls == MaximumNumberOfRolls)
				{
					IsStarted = false;
                    var maxPoint = Players.Max(player => player.PokerHands.Points);
                    var winners = Players.Where(player => player.PokerHands.Points == maxPoint);
                    var message = winners.Count() == 1 ? $"The winner is: {winners.First()}" :
                        $"The winners are {String.Join(", ", winners)}";
                    MessageBox.Show(message, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            return Roll();
        }

        public List<byte> ReRoll(params byte[] notKeepedIndexes)
        {
            CheckGameState();
            LastRollResult = CurrentPlayer.ReRoll(notKeepedIndexes);
            return LastRollResult;
        }

        private void CheckGameState()
        {
            if (!IsStarted)
            {
                throw new InvalidOperationException("Start the game first.");
            }
        }

        public List<byte> Start(List<Player> players)
        {
            Players = players;
            IsStarted = true;
            currentNumberOfRolls = 0;
            SetDefaultPlayerIndex();
            return Roll();
        }

        private List<byte> Roll()
        {
            if (currentNumberOfRolls == MaximumNumberOfRolls)
            {
                throw new InvalidOperationException("Game over, start new game.");
            }

            LastRollResult = CurrentPlayer.Roll();
            return LastRollResult;
        }

        private void SetDefaultPlayerIndex()
        {
            playerIndex = 0;
        }

        private byte GetNextPlayerIndex()
        {
            var nextPlayerIndex = (byte)(playerIndex + 1);
            if (nextPlayerIndex == Players.Count)
            {
                return 0;
            }
            return nextPlayerIndex;
        }

        public List<ComputerPokerHandResult> CheckComputerPlayersTurn()
        {
            var result = new List<ComputerPokerHandResult>();

            while (NextPlayer.PlayerType == PlayerType.Computer)
            {
                var computer = NextPlayer as ComputerPlayer;
                var pokerHandResult = computer.UseArtificialIntelligence();
                result.Add(new ComputerPokerHandResult
                {
                    PokerHandType = pokerHandResult.PokerHandType,
                    Values = pokerHandResult.Values,
                    Player = computer
                });
                playerIndex++;
                if (playerIndex == Players.Count)
                {
                    SetDefaultPlayerIndex();
                }
            }
            return result;
        }
    }
}
