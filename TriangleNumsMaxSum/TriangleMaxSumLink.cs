using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleNumsMaxSum
{
     public class TriangleMaxSumLink : IEnumerator, IEnumerable
    {
        public int this[int index]
        {
            get { return triangleRowItems[index]; }
            private set { triangleRowItems[index] = value; }
        }

        public TriangleMaxSumLink head { get; private set; }
        public TriangleMaxSumLink triangleUp { get; private set; }
        public TriangleMaxSumLink triangleDown { get; set; }

       

        public int[] triangleRowItems { get; set; }
        int position = -1;
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            position++;
            return (position < triangleRowItems.Length);
        }

        public void Reset()
        { position = 0; }

        public object Current
        {
            get { return triangleRowItems[position]; }
        }

        public TriangleMaxSumLink(string s = "759564174782183587102004824765190123750334880277730763679965042806167092414126568340807033414872334732371694295371446525439152975114701133287773177839681757917152381714914358502729486366046889536730731669874031046298272309709873933853600423", int _lenghtRow = 1, TriangleMaxSumLink _head = null)
        {

            head = _head == null ? this : _head;
            this.triangleRowItems = new int[_lenghtRow];
            for (int j = 0; j < _lenghtRow; j++)
            {
                this[j] = Convert.ToInt32(s.Substring(0, 2));
                s = s.Substring(2);
            }

            if (s.Length > (_lenghtRow) * 2)
            {
                this.triangleDown = new TriangleMaxSumLink(s, ++_lenghtRow, head);
                this.triangleDown.head = head;
                this.triangleDown.triangleUp = this;
            }

        }
        public int FindMaxSum(out List<int> ItemIndex)
        {
            ItemIndex = new List<int>();
            ItemIndex.Add(head.triangleRowItems[0]);
            TriangleMaxSumLink items = this.head.triangleDown;
            int loaclSum = 0;
            int sum = head.triangleRowItems[0];

            int maxNumIdex = 0;
            int doubleDownIndex = -1;
            int downIndex = -1;

            while (items.triangleDown != null)
            {
                for (int i = maxNumIdex - 1; i <= maxNumIdex + 1; i++)
                {
                    if (i < 0 || items == null) continue;                 
                    for (int j = i - 1; j <= i + 1; j++)
                    {
                        if (j < 0 || items.triangleDown == null) continue;                       
                        if (loaclSum < items.triangleRowItems[i] + items.triangleDown.triangleRowItems[j])
                        {
                            loaclSum = items.triangleRowItems[i] + items.triangleDown.triangleRowItems[j];
                            doubleDownIndex = j;
                            downIndex = i;
                        }
                    }


                }

                ItemIndex.Add(items.triangleRowItems[downIndex]);
                ItemIndex.Add(items.triangleDown.triangleRowItems[doubleDownIndex]);

                maxNumIdex = doubleDownIndex;
                sum += loaclSum;
                loaclSum = 0;

                downIndex = -1;
                doubleDownIndex = -1;
                if (items.triangleDown?.triangleDown != null)
                    items = items.triangleDown.triangleDown;
                else
                {
                    items = items.triangleDown.triangleDown;
                    break;
                }
            }
            if (items != null)
            {
                
                for (int i = maxNumIdex - 1; i < maxNumIdex + 1; i++)
                {
                    if (i < 0 || i >= items.triangleRowItems.Length) continue;                    
                    sum += loaclSum < items.triangleRowItems[i] ? items.triangleRowItems[i] : sum;
                    downIndex = i;
                }
                ItemIndex.Add(items.triangleRowItems[downIndex]);


            }
            return sum;
        }

    }
}
