using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleNumsMaxSum
{
    public class TriangleFoldingMaxSum
    {
        Stack<int[]> ItemsRows = new Stack<int[]>();

        public TriangleFoldingMaxSum(string s = "759564174782183587102004824765190123750334880277730763679965042806167092414126568340807033414872334732371694295371446525439152975114701133287773177839681757917152381714914358502729486366046889536730731669874031046298272309709873933853600423")
        {
            while (s.Length >= ItemsRows.Count * 2)
            {
                int[] ItemsInRow = new int[ItemsRows.Count + 1];
                for (int i = 0; i < ItemsInRow.Count(); i++)
                {
                    ItemsInRow[i] = Convert.ToInt32(s.Substring(0, 2));                  
                    s = s.Substring(2);
                }
                ItemsRows.Push(ItemsInRow);
            }
        }
       
        public int FindMaxSum(bool enableDataLost = false)
        {
            bool firstCycleLock = true;
            int[] downLevel = null;
            int[] doubleDownLevel = null;
            Stack<int[]> stackClone;
            if (enableDataLost)
            {
                stackClone = ItemsRows;
            }
            else
            {
                stackClone = new Stack<int[]>(ItemsRows.Reverse());
            }

            foreach (int[] Row in stackClone)
            {

                doubleDownLevel = downLevel;
                downLevel = Row;
                if (firstCycleLock)
                {
                    firstCycleLock = false;
                    continue;
                }
                for (int i = 0; i < downLevel.Length; i++)
                {
                    int maxNum = -1;
                    for (int j = i - 1; j <= i + 1; j++)
                    {
                        if (j < 0 || j >= doubleDownLevel.Length) continue;                       
                        maxNum = maxNum < doubleDownLevel[j] ? doubleDownLevel[j] : maxNum;
                    }
                    downLevel[i] += maxNum;

                }
            }
            return downLevel[0];
        }
        
    }
}
