using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DicePoker
{
    public static class ListExtension
    {
        public static ListViewItem ToListViewItem<T>(this List<T> elements, Player player, string type)
        {
			var item = new ListViewItem(player.DisplayName);
            for (int i = 0; i < elements.Count; i++)
            {
                item.SubItems.Add(elements[i].ToString());
            }
            item.SubItems.Add(type);
            item.SubItems.Add(player.PokerHands.Points.ToString());
            return item;
        }
    }
}
