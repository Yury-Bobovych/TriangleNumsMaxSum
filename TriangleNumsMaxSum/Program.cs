using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace TriangleNumsMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = @"bigNums.txt";
            List<int> way1 = new List<int>();
            List<int> way2 = new List<int>();
            int result = 0;
            Console.WriteLine("Small triangle\n");
            Console.WriteLine("TriangleMaxSumLink");
            
            Stopwatch sw = Stopwatch.StartNew();            
            TriangleMaxSumLink triangLink = new TriangleMaxSumLink();
            result = triangLink.FindMaxSum(out way1);
            sw.Stop();

            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();

            Console.WriteLine("TriangleMaxSumValue");
            sw.Start();
            TriangleMaxSumValue triangVal = new TriangleMaxSumValue();
            result = triangVal.FindMaxSum(out way2);
            sw.Stop();
            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();

            Console.WriteLine("TriangleFoldingMaxSum with data lost");
            sw.Start();
            TriangleFoldingMaxSum triangFolding = new TriangleFoldingMaxSum();
            result = triangFolding.FindMaxSum(true);
            sw.Stop();
            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();

            Console.WriteLine("TriangleFoldingMaxSum without data lost");
            sw.Start();
            TriangleFoldingMaxSum triangFoldingDL = new TriangleFoldingMaxSum();
            result = triangFoldingDL.FindMaxSum();
            sw.Stop();
            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();
            string text;
             
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                text = reader.ReadToEnd();
            }



            Console.WriteLine("Big triangle\n");
            Console.WriteLine("TriangleMaxSumLink");

            sw.Start();
            TriangleMaxSumLink BigTriangLink = new TriangleMaxSumLink(text);
            result = BigTriangLink.FindMaxSum(out way1);
            sw.Stop();

            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();

            Console.WriteLine("TriangleMaxSumValue");
            sw.Start();
            TriangleMaxSumValue BigTriangVal = new TriangleMaxSumValue(text);
            result = BigTriangVal.FindMaxSum(out way2);
            sw.Stop();
            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();

            Console.WriteLine("TriangleFoldingMaxSum with data lost");
            sw.Start();
            TriangleFoldingMaxSum BigTriangFolding = new TriangleFoldingMaxSum(text);
            result = BigTriangFolding.FindMaxSum(true);
            sw.Stop();
            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();

            Console.WriteLine("TriangleFoldingMaxSum without data lost");
            sw.Start();
            TriangleFoldingMaxSum BigTriangFoldingDL = new TriangleFoldingMaxSum(text);
            result = BigTriangFoldingDL.FindMaxSum();
            sw.Stop();
            Console.WriteLine($"\tMax sum = {result}\n \tRun time = {sw.ElapsedTicks} tickes\n");
            sw.Reset();


            Console.ReadLine();
        }
    }
}
