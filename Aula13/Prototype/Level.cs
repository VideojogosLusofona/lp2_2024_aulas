using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Level
    {
        private char category;

        public char Category { get => category; set => category = value; }

        private IList<int> scores;

        public Level(char category, IEnumerable<int> scores)
        {
            this.category = category;
            this.scores = new List<int>(scores);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{category}:");
            foreach (float sc in scores) sb.Append($" {sc}");
            return sb.ToString();
        }

        public void IncScores()
        {
            for (int i = 0; i < scores.Count; i++) scores[i] += 1;
        }

        public Level ShallowCopy()
        {
            return MemberwiseClone() as Level;
        }

        public Level DeepCopy()
        {
            Level levelCopy = MemberwiseClone() as Level;
            levelCopy.scores = new List<int>(scores);
            return levelCopy;
        }
    }
}