using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.MazeGrid;
using UnityEngine;

namespace Assets.Scripts.Pathfinding {

    /**
     * Responsible for handling , queueing and proccessing path requests
     */
    public static class PathfinderHandler {

        private static PathfinderNode[,] pathfinderGrid;
        private static Queue<PathRequest> incomingRequests = new Queue<PathRequest>();
        public static bool ThreadLocked = false;
        public static int GridCount { get; private set; }

        private static PathfinderNode VectorToNode(Vector3 position) {
            int x = Mathf.RoundToInt(position.x);
            int z = Mathf.RoundToInt(position.z);
            return pathfinderGrid[x, z];
        }

        public static void SetGrid(MazeNode[,] mazeGrid, int sizeX, int sizeZ) {
            MazeNodeToPathfinderNode converter = new MazeNodeToPathfinderNode(sizeX, sizeZ);
            pathfinderGrid = converter.Convert(mazeGrid);
            GridCount = pathfinderGrid.Length;
        }

        public static void NewPathRequest(Vector3 startingPosition, Vector3 endingPosition, PathRequest.functionToCall action) {
            PathfinderNode start = VectorToNode(startingPosition);
            PathfinderNode end = VectorToNode(endingPosition);
            PathRequest newRequest = new PathRequest(start, end, action);
            incomingRequests.Enqueue(newRequest);
        }

        public static void Tick() {
            if (!ThreadLocked && incomingRequests.Count != 0) {
                PathRequest toProccess = incomingRequests.Dequeue();
                Thread thread = new Thread(() => PathCalculator.StartPathfinding(toProccess));
                ThreadLocked = true;
                thread.Start();
            }
        }
    }
}