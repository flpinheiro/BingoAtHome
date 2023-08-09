﻿using System.Text;

namespace BingoAtHome.Domain
{
    public class Bingo
    {
        public int? Number { get; private set; }
        public List<int> DrawnNumbers { get; } 
        public List<int> NotDrawnNumbers { get; }
        private static Random rnd = new();
        public Bingo(int size = 75)
        {
            NotDrawnNumbers = new List<int>(size);
            for(int i = 1;i<=size;i++) NotDrawnNumbers.Add(i);
            DrawnNumbers = new List<int>(size);
        }

        public void Draw()
        {
            if (NotDrawnNumbers.Count == 0) return;

            var index = rnd.Next(NotDrawnNumbers.Count);
            Number = NotDrawnNumbers[index];
            NotDrawnNumbers.RemoveAt(index);
            DrawnNumbers.Add(Number??0);
            DrawnNumbers.Sort();
        }

        public bool IsDraw(int number)
        {
            return DrawnNumbers.Contains(number);
        }
    }
}
