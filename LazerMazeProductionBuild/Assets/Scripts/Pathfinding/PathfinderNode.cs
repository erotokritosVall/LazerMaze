﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathfinding {

    /**
     * Node of the graph that will be used for pathfinding
     */

    public class PathfinderNode : IHeapItem<PathfinderNode> {
        private HashSet<PathfinderNode> neighbors = new HashSet<PathfinderNode>();
        public HashSet<PathfinderNode> Neighbors {
            get { return neighbors; }
        }
        public Vector3 Position { get; private set; }
        public PathfinderNode Parent { get; set; }
        public int GScore { get; set; }
        public int HScore { get; set; }
        public int FScore {
            get { return (GScore + HScore); }
        }
        int IHeapItem<PathfinderNode>.HeapIndex { get; set; }

        public PathfinderNode(Vector3 position) {
            Position = position;
        }

        public void AddNeighbor(PathfinderNode neighbor) {
            neighbors.Add(neighbor);
        }

        public int CompareTo(PathfinderNode toCompare) {
            int compare = FScore.CompareTo(toCompare.FScore);
            if (compare == 0) {
                compare = HScore.CompareTo(toCompare.HScore);
            }
            return -compare;
        }
    }
}
