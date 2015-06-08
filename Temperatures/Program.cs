using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
	static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
		string TEMPS = Console.ReadLine(); // the N temperatures expressed as integers ranging from -273 to 5526

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		if (N == 0)
		{
			Console.WriteLine("0");
			return;
		}

		var temps = TEMPS.Split();

		int minAbs = int.MaxValue;
		int nearest = minAbs;
		for (int i = 0; i < temps.Length; i++)
		{
			int t = int.Parse(temps[i]);
			int tAbs = Math.Abs(t);
			if (minAbs > tAbs)
			{
				minAbs = tAbs;
				nearest = t;
			}
			else if (minAbs == tAbs)
			{
				nearest = Math.Max(t, nearest);
			}
		}
		Console.WriteLine(nearest);
	}
}
