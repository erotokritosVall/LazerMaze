using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathfinding {

    /**
     * Node of the graph that will be used for pathfinding.
     * Implements IHeapItem so it can be used in a BinaryHeap
     */
    public class PathfinderNode : IHeapItem<PathfinderNode> {

        private HashSet<PathfinderNode> neighbors = new HashSet<PathfinderNode>();
        public HashSet<PathfinderNode> Neighbors {
            get { return neighbors; }
        }

        public Vector3 Position { get; private set; }
        public AStarData Data;
        public int HeapIndex { get; set; }

        public PathfinderNode(Vector3 position) {
            Position = position;
        }

        //If two nodes' FScores are equal , we compare the H scoares. They can't both be equal!
        public int CompareTo(PathfinderNode toCompare) {
            int compare = Data.FScore.CompareTo(toCompare.Data.FScore);
            if (compare == 0) {
                compare = Data.HScore.CompareTo(toCompare.Data.HScore);
            }
            return -compare;
        }

        public void AddNeighbor(PathfinderNode neighbor) {
            neighbors.Add(neighbor);
        }
    }

    //Data needed for the A* algorithm to run , all packed in a single struct
    public struct AStarData {
        public int GScore { get; set; }
        public float HScore { get; set; }
        public float FScore {
            get { return GScore + HScore; }
        }
        public PathfinderNode Parent { get; set; }
    }
}
