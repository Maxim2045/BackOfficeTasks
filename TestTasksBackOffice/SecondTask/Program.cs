using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Введите число");
			double x = double.Parse(Console.ReadLine());
			List<double> numsInFile = new List<double>();
			using (StreamReader sr = new StreamReader("nums.txt"))
			{
				while (!sr.EndOfStream)
					numsInFile.Add(double.Parse(sr.ReadLine()));
			}
			List<double> numsSorted = numsInFile.GetRange(0, numsInFile.Count);
			numsSorted.Sort();

			bool found = false;

			foreach (double num in numsSorted)
			{
				//double first = num;
				double second = x - num; 
				int indexSecond = numsSorted.BinarySearch(second);
				if (indexSecond > -1 && indexSecond != numsSorted.IndexOf(num))
				{
					Console.WriteLine("{0} and {1}; values {2} and {3}", numsInFile.IndexOf(num), numsInFile.IndexOf(second), num, second);
					found = true;
					break;
				}
			}

			if (!found)
			{

				Console.WriteLine("Нет таких чисел");
			}
			Console.ReadKey();

		}
	}
}
