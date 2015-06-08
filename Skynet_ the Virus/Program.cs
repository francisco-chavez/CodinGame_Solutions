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
		int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
		int L = int.Parse(inputs[1]); // the number of links
		int E = int.Parse(inputs[2]); // the number of exit gateways

		Graph graph = new Graph(N);
		for (int i = 0; i < L; i++)
		{
			inputs = Console.ReadLine().Split(' ');
			int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
			int N2 = int.Parse(inputs[1]);

			graph.AddEdge(N1, N2);
		}

		for (int i = 0; i < E; i++)
		{
			int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
			graph.AddExitNode(EI);
		}

		// game loop
		var path = new int[] { 0, 1 };
		while (true)
		{
			int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

			var minPathLengthMatrix = graph.GetNodePathLengthArray(SI);

			int nearestExitNodeID = -1;
			foreach (var exitID in graph.GetExitNodeIDs())
			{
				int thisExitNodeIndex = graph.GetNodeIndex(exitID);
				if (minPathLengthMatrix[thisExitNodeIndex] == -1)
					continue;

				if (nearestExitNodeID == -1)
				{
					nearestExitNodeID = exitID;
				}
				else
				{
					int minExitNodeIndex = graph.GetNodeIndex(nearestExitNodeID);
					if (minPathLengthMatrix[thisExitNodeIndex] < minPathLengthMatrix[minExitNodeIndex])
						nearestExitNodeID = exitID;
				}
			}

			path = graph.GetShortestPath(SI, nearestExitNodeID, minPathLengthMatrix[graph.GetNodeIndex(nearestExitNodeID)] + 1);
			graph.RemoveEdge(path[0], path[1]);

			Console.WriteLine("{0} {1}", path[0], path[1]);
			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			//Console.WriteLine("0 1"); // Example: 0 1 are the indices of the nodes you wish to sever the link between
		}
	}
}

public class Graph
{
	#region Helper Classes
	public class Node
	{
		private HashSet<Node>   _neighbors;
		private int             _id         = -1;


		public Node(int id)
		{
			_id = id;
			_neighbors = new HashSet<Node>();
		}


		public IEnumerable<Node> Neighbors
		{
			get { return _neighbors; }
		}

		public int Degree
		{
			get { return _neighbors.Count; }
		}

		public int ID
		{
			get { return _id; }
		}

		public void AddNeighbor(Node node)
		{
			_neighbors.Add(node);
		}

		public void RemoveNeighbor(Node node)
		{
			_neighbors.Remove(node);
		}
	}
	#endregion


	private Dictionary<int, Node>   _nodes;
	private HashSet<int>            _exitNodeIDs;
	private Dictionary<int, int>    _nodeIDToIndex;
	private int                     _nextNodeIndex = 0;


	public Graph(int n)
	{
		_nodes = new Dictionary<int, Node>(n);
		_exitNodeIDs = new HashSet<int>();
		_nodeIDToIndex = new Dictionary<int, int>(n);
	}


	public void AddEdge(int idA, int idB)
	{
		if (!_nodes.ContainsKey(idA))
		{
			_nodes.Add(idA, new Node(idA));
			_nodeIDToIndex.Add(idA, _nextNodeIndex++);
		}

		if (!_nodes.ContainsKey(idB))
		{
			_nodes.Add(idB, new Node(idB));
			_nodeIDToIndex.Add(idB, _nextNodeIndex++);
		}

		_nodes[idA].AddNeighbor(_nodes[idB]);
		_nodes[idB].AddNeighbor(_nodes[idA]);
	}

	public void RemoveEdge(int idA, int idB)
	{
		var nodeA = this._nodes[idA];
		var nodeB = this._nodes[idB];

		nodeA.RemoveNeighbor(nodeB);
		nodeB.RemoveNeighbor(nodeA);
	}

	public void AddExitNode(int nodeID)
	{
		if (!_nodes.ContainsKey(nodeID))
			throw new Exception(string.Format("Node: '{0}' is not part of the graph.", nodeID));

		_exitNodeIDs.Add(nodeID);
	}

	public int GetNodeIndex(int nodeID)
	{
		return _nodeIDToIndex[nodeID];
	}

	public IEnumerable<int> GetExitNodeIDs()
	{
		return _exitNodeIDs;
	}

	public int[] GetNodePathLengthArray(int startingNodeID)
	{
		int n = _nodes.Count;
		int[] result = new int[n];

		for (int i = 0; i < n; i++)
			result[i] = -1;

		int startIndex = this._nodeIDToIndex[startingNodeID];
		result[startIndex] = 0;

		FillMinPathLengthMatrix(startingNodeID, ref result, 1);
		return result;
	}

	private void FillMinPathLengthMatrix(int startNodeID, ref int[] matrix, int currentPathLength)
	{
		var startNode = this._nodes[startNodeID];
		foreach (var node in startNode.Neighbors)
		{
			var nodeIndex = this._nodeIDToIndex[node.ID];
			if (matrix[nodeIndex] == -1)
			{
				matrix[nodeIndex] = currentPathLength;
				FillMinPathLengthMatrix(node.ID, ref matrix, currentPathLength + 1);
			}
			else if (matrix[nodeIndex] > currentPathLength)
			{
				matrix[nodeIndex] = currentPathLength;
				FillMinPathLengthMatrix(node.ID, ref matrix, currentPathLength + 1);
			}
		}
	}

	public int[] GetShortestPath(int startingNodeID, int endingNodeID, int maxPathLength)
	{
		HashSet<int> nodesInPath = new HashSet<int>();
		nodesInPath.Add(startingNodeID);
		List<int> path = new List<int>(maxPathLength);
		path.Add(startingNodeID);

		var startNode = this._nodes[startingNodeID];

		foreach (var node in startNode.Neighbors)
		{
			path.Add(node.ID);
			nodesInPath.Add(node.ID);

			if (node.ID == endingNodeID)
				break;

			if (GetShortestPath(node.ID, endingNodeID, nodesInPath, path, maxPathLength))
				break;

			path.RemoveAt(path.Count - 1);
			nodesInPath.Remove(node.ID);
		}

		return nodesInPath.ToArray();
	}

	private bool GetShortestPath(int startingNodeID, int endingNodeID, HashSet<int> excludeNodes,
								 List<int> path, int maxPathLength)
	{
		if (path.Count > maxPathLength)
			return false;
		if (path.Count == maxPathLength)
			return path.Last() == endingNodeID;

		var startingNode = this._nodes[startingNodeID];
		foreach (var node in startingNode.Neighbors)
		{
			if (excludeNodes.Contains(node.ID))
				continue;

			path.Add(node.ID);
			excludeNodes.Add(node.ID);

			if (GetShortestPath(node.ID, endingNodeID, excludeNodes, path, maxPathLength))
				return true;

			path.RemoveAt(path.Count - 1);
			excludeNodes.Remove(node.ID);
		}
		return false;
	}
}
