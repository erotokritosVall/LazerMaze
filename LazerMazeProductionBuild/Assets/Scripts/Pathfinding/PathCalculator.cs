using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathfinding {

    /**
     * Calculates the path, reconstructs it and handles it to the requester through the delegate function
     */
    public static class PathCalculator {

        private static Stack<Vector3> ReconstructPath(PathRequest request) {
            Stack<Vector3> path = new Stack<Vector3>();
            PathfinderNode current = request.TargetPosition;
            do {
                path.Push(current.Position);
                current = current.Parent;
            } while (current != request.StartingPosition);
            return path;
        }

        private static int CalculateManhattanDistance(Vector3 startingPosition, Vector3 targetPosition) {
            float xManhattan = Mathf.Abs(startingPosition.x - targetPosition.x);
            float zManhattan = Mathf.Abs(startingPosition.z - targetPosition.z);
            return (int)(xManhattan + zManhattan);
        }

        //A* algorithm implementation
        public static void StartPathfinding(PathRequest request) {
            BinaryHeap<PathfinderNode> openSet = new BinaryHeap<PathfinderNode>(PathfinderHandler.GridCount);
            HashSet<PathfinderNode> closedSet = new HashSet<PathfinderNode>();
            request.StartingPosition.GScore = 0;
            request.StartingPosition.HScore = CalculateManhattanDistance(request.StartingPosition.Position, request.TargetPosition.Position);
            openSet.Add(request.StartingPosition);
            while (openSet.Count != 0) {
                PathfinderNode current = openSet.RemoveFirst();
                closedSet.Add(current);
                if (current == request.TargetPosition) {
                    request.FunctionToCall(ReconstructPath(request));
                    PathfinderHandler.ThreadLocked = false;
                    return;
                }
                foreach (PathfinderNode neighbor in current.Neighbors) {
                    if (closedSet.Contains(neighbor))
                        continue;
                    int currentGScore = current.GScore + 1;
                    if (currentGScore < neighbor.GScore || !openSet.Contains(neighbor)) {
                        neighbor.GScore = currentGScore;
                        neighbor.HScore = CalculateManhattanDistance(neighbor.Position, request.TargetPosition.Position);
                        neighbor.Parent = current;
                        if (!openSet.Contains(neighbor)) {
                            openSet.Add(neighbor);
                        } else {
                            openSet.UpdateItem(neighbor);
                        }
                    }
                }
            }
            //If path not found(never happens) unlock thread
            PathfinderHandler.ThreadLocked = false;
        }
    }
}
