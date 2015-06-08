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
class Player
{
	static void Main(string[] args)
	{
		string[] inputs;
		int N = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
		List<Tuple<int, int>> land = new List<Tuple<int, int>>();
		for (int i = 0; i < N; i++)
		{
			inputs = Console.ReadLine().Split(' ');
			Console.Error.WriteLine("{0}, {1}", inputs[0], inputs[1]);
			int LAND_X = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
			int LAND_Y = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
		}

		// game loop
		bool useHigh = true;
		while (true)
		{
			inputs = Console.ReadLine().Split(' ');
			int X = int.Parse(inputs[0]);
			int Y = int.Parse(inputs[1]);
			int HS = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
			int VS = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
			int F = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
			int R = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
			int P = int.Parse(inputs[6]); // the thrust power (0 to 4).

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			if (useHigh)
			{
				if (VS > -36)
					useHigh = false;
			}
			else
			{
				if (VS < -46)
					useHigh = true;
			}
			if (useHigh)
				Console.WriteLine("0 4");
			else
				Console.WriteLine("0 1");
			//Console.WriteLine("-20 3"); // R P. R is the desired rotation angle. P is the desired thrust power.
		}
	}

	static float FindLandHeight(int x)
	{
		throw new NotImplementedException();
	}
}