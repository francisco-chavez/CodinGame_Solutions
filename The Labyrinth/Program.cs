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
		switch (searchMode)
		{
		case CurrentMode.Heading:
			return HeadsToControlRoom(maze, x, y, w, h);
		case CurrentMode.Returning:
			return ReturnToStartingPoint(maze, x, y, w, h);
		case CurrentMode.Searching:
			return LookForControlRoom(maze, x, y, w, h);
		default:
			throw new Exception("Unknown search mode entered");
		}
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

	/// <summary>
	/// Returns true if the location of the control room has been found. This is not
	/// to be confused with the path to the control room.
	/// </summary>
	/// <param name="maze">The latest scan of the maze.</param>
	/// <param name="w">The width of the maze.</param>
	/// <param name="h">The height of the maze.</param>
	/// <returns>
	/// A boolean value telling you that the lastest scan shows the location of the control room.
	/// </returns>
	static bool ControlRoomFound(char[,] maze, int w, int h)
	{
		for (int i = 0; i < h; i++)
			for (int j = 0; j < w; j++)
				if (maze[i, j] == 'C')
					return true;
		return false;
	}

	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int rowCount		= int.Parse(inputs[0]);	// number of rows.
		int columnCount		= int.Parse(inputs[1]); // number of columns.
		int alarmCountDown	= int.Parse(inputs[2]); // number of rounds between the time the alarm countdown is activated and the time the alarm goes off.

		// game loop
		char[,] maze = new char[rowCount, columnCount];

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
