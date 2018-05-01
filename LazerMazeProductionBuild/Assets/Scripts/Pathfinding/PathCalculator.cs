using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Managers;
using System.Threading;

namespace Assets.Scripts.Pathfinding {

    /**
     * Calculates the path, reconstructs it and handles it to the requester through the delegate function
     */
    public class PathCalculator {
        private PathRequest request;
        private PathfinderNode[,] grid;
        private PathfinderNode startingNode;
        private PathfinderNode targetNode;
        private BinaryHeap<PathfinderNode> openSet;
        private HashSet<PathfinderNode> closedSet;

        public PathCalculator(PathRequest request, PathfinderNode[,] grid) {
            this.request = request;
            this.grid = grid;
            startingNode = VectorToNode(request.StartingPosition);
            targetNode = VectorToNode(request.TargetPosition);
            openSet = new BinaryHeap<PathfinderNode>(grid.Length);
            closedSet = new HashSet<PathfinderNode>();
        }

        private Stack<Vector3> ReconstructPath() {
            Stack<Vector3> path = new Stack<Vector3>();
            PathfinderNode current = targetNode;
            do {
                path.Push(current.Position);
                current = current.Data.Parent;
            } while (current != startingNode);
            return path;
        }

        private PathfinderNode VectorToNode(Vector3 vector) {
            int xPos = Mathf.RoundToInt(vector.x);
            int zPos = Mathf.RoundToInt(vector.z);
            return grid[xPos, zPos];
        }

        private float CalculateManhattanDistance(Vector3 startingPosition) {
            float xManhattan = Mathf.Abs(startingPosition.x - targetNode.Position.x);
            float zManhattan = Mathf.Abs(startingPosition.z - targetNode.Position.z);
            return xManhattan + zManhattan;
        }

        //A* algorithm implementation
        public void StartPathfinding() {
            List<Vector3> indexes = new List<Vector3>();
            indexes.Add(startingNode.Position);
            startingNode.Data.HScore = CalculateManhattanDistance(startingNode.Position);
            openSet.Add(startingNode);
            while (openSet.Count > 0) {
                PathfinderNode current = openSet.RemoveFirst();
                if (current.Equals(targetNode)) {
                    break;
                }
                foreach (PathfinderNode neighbor in current.Neighbors) {
                    if (closedSet.Contains(neighbor)) {
                        continue;
                    }
                    int currentGScore = current.Data.GScore + 1;
                    if (currentGScore < neighbor.Data.GScore || !openSet.Contains(neighbor)) {
                        neighbor.Data.GScore = currentGScore;
                        neighbor.Data.HScore = CalculateManhattanDistance(neighbor.Position);
                        neighbor.Data.Parent = current;
                        if (!openSet.Contains(neighbor)) {
                            openSet.Add(neighbor);
                            indexes.Add(neighbor.Position);
                        } else {
                            openSet.UpdateItem(neighbor);
                        }
                    }                  
                }
                closedSet.Add(current);                  
            }
            Stack<Vector3> path = ReconstructPath();
            PathfindingManager.Instance.PathAcquired(path, request, indexes);
        }
    }
}
