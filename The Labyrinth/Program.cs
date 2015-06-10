using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


public enum CurrentMode 
{ 
	Searching,	// Searching to the control room
	Heading,	// Heading towards the control room (only posible if we know where it is)
	Returning	// Returning to starting location
}

class Player
{
	static string FindNextMove(char[,] maze, CurrentMode searchMode, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	static string LookForControlRoom(char[,] maze, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	static string HeadsToControlRoom(char[,] maze, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	static string ReturnToStartingPoint(char[,] maze, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int rowCount		= int.Parse(inputs[0]);	// number of rows.
		int columnCount		= int.Parse(inputs[1]); // number of columns.
		int alarmCountDown	= int.Parse(inputs[2]); // number of rounds between the time the alarm countdown is activated and the time the alarm goes off.

		// game loop
		char[,] maze = new char[columnCount, rowCount];

		while (true)
		{
			// '#' : { Wall }
			// '.' : { Hollow space }
			// 'T' : { Starting position }
			// 'C' : { Control room }
			// '?' : { Un-scanned cell }

			inputs = Console.ReadLine().Split(' ');
			int currentRow		= int.Parse(inputs[0]); // row where Kirk is located.
			int currentColumn	= int.Parse(inputs[1]); // column where Kirk is located.

			for (int i = 0; i < rowCount; i++)
			{
				string ROW = Console.ReadLine(); // C of the characters in '#.TC?' (i.e. one line of the ASCII maze).
				for (int j = 0; j < columnCount; j++)
					maze[i, j] = ROW[j];
			}

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			Console.WriteLine("RIGHT"); // Kirk's next move (UP DOWN LEFT or RIGHT).
		}
	}
}
