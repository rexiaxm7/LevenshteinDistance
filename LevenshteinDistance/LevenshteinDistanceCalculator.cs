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

            var len1 = s1.Length;
            var len2 = s2.Length;

            if (len1 == 0) return len2;
            if (len2 == 0) return len1;

            var matrix = CreateInitializedMatrix(len1 + 1, len2 + 1);

            for (var i = 1; i < len1 + 1; i++)
            {
                for (var j = 1; j < len2 + 1; j++)
                {
                    var distance = s1[i - 1].Equals(s2[j - 1]) ? 0 : 1;
                    var candidates = new[] { matrix[i - 1, j] + 1, matrix[i, j - 1] + 1, matrix[i - 1, j - 1] + distance };
                    matrix[i, j] = candidates.Min();
                }
            }

            return matrix[len1, len2];
        }

        private static int[,] CreateInitializedMatrix(int len1, int len2)
        {
            var matrix = new int[len1, len2];

            for (var i = 0; i < len1; i++)
            {
                matrix[i, 0] = i;
            }

            for (var i = 0; i < len2; i++)
            {
                matrix[0, i] = i;
            }

            return matrix;
        }
    }
}
