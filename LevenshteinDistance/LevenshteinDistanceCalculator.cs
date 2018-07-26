using System;
using System.Linq;

namespace LevenshteinDistance
{
    public static class LevenshteinDistanceCalculator
    {
        public static int Calculate(string text1, string text2) => Calculate(text1, text2, 1, 1, 1);

        public static int Calculate(string text1, string text2, int insertCost, int replaceCost, int deleteCost)
        {
            if (text1 == null) throw new ArgumentNullException("text1");
            if (text2 == null) throw new ArgumentNullException("text2");

            var len1 = text1.Length;
            var len2 = text2.Length;

            if (len1 == 0) return len2;
            if (len2 == 0) return len1;

            var matrix = CreateInitializedMatrix(len1 + 1, len2 + 1);

            for (var i = 1; i < len1 + 1; i++)
            {
                for (var j = 1; j < len2 + 1; j++)
                {
                    var cost = text1[i - 1].Equals(text2[j - 1]) ? 0 : replaceCost;
                    var candidates = new[]
                    {
                        matrix[i - 1, j] + insertCost,
                        matrix[i, j - 1] + deleteCost,
                        matrix[i - 1, j - 1] + cost
                    };
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
