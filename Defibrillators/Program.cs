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
		string LON = Console.ReadLine();
		string LAT = Console.ReadLine();
		int N = int.Parse(Console.ReadLine());

		LON = LON.Replace(',', '.');
		LAT = LAT.Replace(',', '.');

		double longitude = double.Parse(LON);
		double latitude = double.Parse(LAT);

		double distanceSquared = double.MaxValue;
		string defibName = string.Empty;

		for (int i = 0; i < N; i++)
		{
			string DEFIB = Console.ReadLine();
			string[] details = DEFIB.Split(';');
			details[4] = details[4].Replace(',', '.');
			details[5] = details[5].Replace(',', '.');

			var defibLong = double.Parse(details[4]);
			var defibLat = double.Parse(details[5]);

			var deltaX = (defibLong - longitude) * Math.Cos((latitude + defibLat) / 2.0);
			var deltaY = defibLat - latitude;

			double d2 = Math.Pow(deltaX, 2.0) + Math.Pow(deltaY, 2.0);
			if (d2 < distanceSquared)
			{
				distanceSquared = d2;
				defibName = details[1];
			}
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		Console.WriteLine(defibName);
	}
}
