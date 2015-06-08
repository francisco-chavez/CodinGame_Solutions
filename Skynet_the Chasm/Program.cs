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
		int R = int.Parse(Console.ReadLine()); // the length of the road before the gap.
		int G = int.Parse(Console.ReadLine()); // the length of the gap.
		int L = int.Parse(Console.ReadLine()); // the length of the landing platform.

		Console.Error.WriteLine("Runway: {0}", R);
		Console.Error.WriteLine("Gap: {0}", G);
		Console.Error.WriteLine("Landing Pad: {0}", L);




		var hasJumped = false;
		// game loop
		while (true)
		{
			int S = int.Parse(Console.ReadLine()); // the motorbike's speed.
			int X = int.Parse(Console.ReadLine()); // the position on the road of the motorbike.
			Console.Error.WriteLine("Position: {0}", X);

			if (hasJumped)
			{
				Console.WriteLine("SLOW");
			}
			else if (X == R - 1)
			{
				Console.WriteLine("JUMP");
				hasJumped = true;
			}
			else if (S > G + 1)
			{
				Console.WriteLine("SLOW");
			}
			else if (S == G + 1)
			{
				Console.WriteLine("WAIT");
			}
			else
			{
				Console.WriteLine("SPEED");
			}

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			//Console.WriteLine("SPEED"); // A single line containing one of 4 keywords: SPEED, SLOW, JUMP, WAIT.
		}
	}
}
