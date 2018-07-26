using System;
using System.Linq;

namespace LevenshteinDistance
{
    public static class LevenshteinDistanceCalculator
    {
        public static int Calculate(string s1, string s2)
        {
            if (s1 == null) throw new ArgumentNullException("s1");
            if (s2 == null) throw new ArgumentNullException("s2");

            var s1Length = s1.Length;
            var s2Length = s2.Length;

            if (s1Length == 0) return s2Length;
            if (s2Length == 0) return s1Length;

            var matrix = CreateInitializedMatrix(s1Length, s2Length);

            for (var i = 1; i < s1Length + 1; i++)
            {
                for (var j = 1; j < s2Length + 1; j++)
                {
                    var distance = s1[i - 1].Equals(s2[j - 1]) ? 0 : 1;
                    var candidates = new[] { matrix[i - 1, j] + 1, matrix[i, j - 1] + 1, matrix[i - 1, j - 1] + distance };
                    matrix[i, j] = candidates.Min();
                }
            }

            return matrix[s1Length, s2Length];
        }

        private static int[,] CreateInitializedMatrix(int s1Length, int s2Length)
        {
            var matrix = new int[s1Length + 1, s2Length + 1];

            for (var i = 0; i < s1Length + 1; i++)
            {
                matrix[i, 0] = i;
            }

            for (var i = 0; i < s2Length + 1; i++)
            {
                matrix[0, i] = i;
            }

            return matrix;
        }
    }
}
