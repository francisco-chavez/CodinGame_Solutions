using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


#region Helpers
public enum SearchMode 
{ 
	Searching,	// Searching for the control room
	Heading,	// Heading towards the control room (only posible if we know where it is)
	Returning	// Returning to starting location
}

public interface IStrategy
{
	SearchMode CurrentStrategyClassification { get; }
	SearchMode StateNextStrategy(char[,] maze, SearchMode searchMode, int x, int y, int w, int h);
	string FindNextMove(char[,] maze, int x, int y, int w, int h);
}

class SearchClass
	: IStrategy
{
	public string FindNextMove(char[,] maze, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	public SearchMode StateNextStrategy(char[,] maze, SearchMode searchMode, int x, int y, int w, int h)
	{
		if (ControlRoomFound(maze, w, h))
			return SearchMode.Heading;
		else
			return CurrentStrategyClassification;
	}

	public SearchMode CurrentStrategyClassification { get { return SearchMode.Searching; } }

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
}

class ApproachClass
	: IStrategy
{
	public SearchMode CurrentStrategyClassification
	{
		get { throw new NotImplementedException(); }
	}

	public SearchMode StateNextStrategy(char[,] maze, SearchMode searchMode, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	public string FindNextMove(char[,] maze, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}
}

class GoHomeClass
	: IStrategy
{
	public SearchMode CurrentStrategyClassification
	{
		get { throw new NotImplementedException(); }
	}

	public SearchMode StateNextStrategy(char[,] maze, SearchMode searchMode, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}

	public string FindNextMove(char[,] maze, int x, int y, int w, int h)
	{
		throw new NotImplementedException();
	}
}
#endregion


class Player
{
	static IStrategy ControlRoomSearchStrategy		= new SearchClass();
	static IStrategy ControlRoomApproachStrategy	= new ApproachClass();
	static IStrategy ReturnStrategy					= new GoHomeClass();

	static IStrategy CurrentStrategy				= null;

	static void UpdateCurrentStrategy(SearchMode searchMode)
	{
		switch (searchMode)
		{
		case SearchMode.Heading:
			CurrentStrategy = ControlRoomApproachStrategy;
			break;

		case SearchMode.Returning:
			CurrentStrategy = ReturnStrategy;
			break;

		case SearchMode.Searching:
			CurrentStrategy = ControlRoomSearchStrategy;
			break;

		default:
			throw new ArgumentOutOfRangeException("Invalide search strategy has been selected.");
		}
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
		SearchMode searchMode = SearchMode.Searching;
		UpdateCurrentStrategy(searchMode);

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

			searchMode = CurrentStrategy.StateNextStrategy(maze, CurrentStrategy.CurrentStrategyClassification, currentColumn, 
														   currentRow, columnCount, rowCount);
			UpdateCurrentStrategy(searchMode);

			string nextMove = CurrentStrategy.FindNextMove(maze, currentColumn, currentRow, columnCount, rowCount);

			Console.WriteLine(nextMove); // Kirk's next move (UP DOWN LEFT or RIGHT).
		}
	}
}
