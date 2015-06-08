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

			// Find the minimum path length from node SI to any exit node.
			// Also, get all exit nodes that can be reached with that path
			// length.
			int minPathLength = int.MaxValue;
			List<int> exitNodes = new List<int>();

			foreach (var exitID in graph.GetExitNodeIDs())
			{
				int thisExitNodeIndex = graph.GetNodeIndex(exitID);
				if (minPathLengthMatrix[thisExitNodeIndex] == -1)
					continue;

				int nodeIndex = graph.GetNodeIndex(exitID);
				int pathLength = minPathLengthMatrix[nodeIndex];

				if (minPathLength < pathLength)
					continue;

				if (minPathLength == pathLength)
				{
					exitNodes.Add(exitID);
				}
				else if (pathLength < minPathLength)
				{
					exitNodes.Clear();
					exitNodes.Add(exitID);
					minPathLength = pathLength;
				}
			}

			///
			/// Foreach minPath length that can reach an exit node, find the second
			/// to last node and count how many exit nodes it can reach.
			/// 
			Dictionary<int, int> connectivityMap = new Dictionary<int, int>();
			foreach (var exitID in exitNodes)
			{
				foreach (var node in graph.GetNode(exitID).Neighbors)
				{
					if (minPathLengthMatrix[graph.GetNodeIndex(node.ID)] >= minPathLength)
						continue;

					if (!connectivityMap.ContainsKey(node.ID))
						connectivityMap.Add(node.ID, 0);

					connectivityMap[node.ID] += 1;
				}
			}

			// Find the node with the heighest degree of exit nodes.
			// If more than one, just grab the first one.
			int bestStartNode = -1;
			int heighestDegree = 0;
			foreach (var pair in connectivityMap)
			{
				if (pair.Value > heighestDegree)
				{
					heighestDegree = pair.Value;
					bestStartNode = pair.Key;
				}
			}

			int endNode = -1;
			foreach (var node in graph.GetNode(bestStartNode).Neighbors)
			{
				if (graph.GetExitNodeIDs().Contains(node.ID))
				{
					endNode = node.ID;
					break;
				}
			}

			graph.RemoveEdge(bestStartNode, endNode);

			Console.WriteLine("{0} {1}", bestStartNode, endNode);
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

	public Node GetNode(int nodeID)
	{
		return _nodes[nodeID];
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
}
