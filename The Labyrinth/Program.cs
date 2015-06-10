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
		inputs = Console.ReadLine().Split(' ');
		int R = int.Parse(inputs[0]); // number of rows.
		int C = int.Parse(inputs[1]); // number of columns.
		int A = int.Parse(inputs[2]); // number of rounds between the time the alarm countdown is activated and the time the alarm goes off.

		// game loop
		while (true)
		{
			inputs = Console.ReadLine().Split(' ');
			int KR = int.Parse(inputs[0]); // row where Kirk is located.
			int KC = int.Parse(inputs[1]); // column where Kirk is located.
			for (int i = 0; i < R; i++)
			{
				string ROW = Console.ReadLine(); // C of the characters in '#.TC?' (i.e. one line of the ASCII maze).
			}

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			Console.WriteLine("RIGHT"); // Kirk's next move (UP DOWN LEFT or RIGHT).
		}
	}
}
