﻿using System.Collections.Generic;

namespace DiePoker
{
    public class PokerHandResult
    {
        public PokerHandType PokerHandType { get; set; }

        public List<byte> Values { get; set; }

        public override string ToString()
        {
            return PokerHandType.ToString();
        }
    }
}
