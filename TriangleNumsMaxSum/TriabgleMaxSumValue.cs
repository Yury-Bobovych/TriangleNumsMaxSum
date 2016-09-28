using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleNumsMaxSum
{
    /// <summary>
    /// heuristic a
    /// </summary>
    public class TriangleMaxSumValue
    {
        int[][] ItemsRows = new int[0][];
        public TriangleMaxSumValue(string s = "759564174782183587102004824765190123750334880277730763679965042806167092414126568340807033414872334732371694295371446525439152975114701133287773177839681757917152381714914358502729486366046889536730731669874031046298272309709873933853600423")
        {
            while (s.Length >= ItemsRows.Length * 2)
            {
                int[] ItemsInRow = new int[ItemsRows.Length + 1];
                for (int i = 0; i < ItemsInRow.Count(); i++)
                {
                    ItemsInRow[i] = Convert.ToInt32(s.Substring(0, 2));
                    s = s.Substring(2);
                }
                Array.Resize<int[]>(ref ItemsRows, ItemsRows.Length + 1);
                ItemsRows[ItemsInRow.Length - 1] = ItemsInRow;
            }

        }
        public int FindMaxSum(out List<int> ItemIndex)
        {
            ItemIndex = new List<int>();
            ItemIndex.Add(ItemsRows[0][0]);

            int loaclSum = 0;
            int sum = ItemsRows[0][0];

            int maxNumIdex = 0;
            int doubleDownIndex = -1;
            int downIndex = -1;


            for (int i = 1; i < ItemsRows.Length - 1; i += 2)
            {
                for (int j = maxNumIdex - 1; j <= maxNumIdex + 1; j++)
                {
                    if (j < 0 || j > ItemsRows[i].Length) continue;
                    for (int k = j - 1; k <= j + 1; k++)
                    {
                        if (k < 0|| k > ItemsRows[i + 1].Length) continue;                       
                        if (loaclSum < ItemsRows[i][j] + ItemsRows[i + 1][k])
                        {
                            loaclSum = ItemsRows[i][j] + ItemsRows[i + 1][k];
                            doubleDownIndex = k;
                            downIndex = j;
                        }
                    }
                }
                ItemIndex.Add(ItemsRows[i][downIndex]);
                ItemIndex.Add(ItemsRows[i + 1][doubleDownIndex]);

                maxNumIdex = doubleDownIndex;
                sum += loaclSum;
                loaclSum = 0;

                downIndex = -1;
                doubleDownIndex = -1;

            }
            if (ItemIndex.Count < ItemsRows.Length)
            {

                for (int i = maxNumIdex - 1; i < maxNumIdex + 1; i++)
                {
                    if (i < 0 || i >= ItemsRows[ItemsRows.Length-1].Length) continue;
                    
                    sum += loaclSum < ItemsRows[ItemsRows.Length - 1][i] ? ItemsRows[ItemsRows.Length - 1][i] : sum;
                    downIndex = i;
                }
                ItemIndex.Add(ItemsRows[ItemsRows.Length - 1][downIndex]);


            }
            return sum;
        }
    }
}
