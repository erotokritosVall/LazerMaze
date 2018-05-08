using System.Collections.Generic;
using System;
using System.Threading;
using Assets.Scripts.Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Responsible for handling , queueing and proccessing path requests as well as creating the pathfinder grid
     */

    public class PathfindingManager : MonoBehaviour {

        private Queue<PathRequest> incomingRequests = new Queue<PathRequest>();
        private bool bIsThreadLocked = false;

        public PathfinderNode[,] PathfinderGrid { get; private set; }
        public static PathfindingManager Instance { get; private set; }

        private PathfindingManager() { }

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
            else if (Instance != this) {
                Destroy(this);
            }
        }

        private void Tick() {
            if (incomingRequests.Count > 0 && !bIsThreadLocked) {
                PathRequest toProccess = incomingRequests.Dequeue();
                PathCalculator pathCalculator = new PathCalculator(toProccess);
                Thread thread = new Thread(pathCalculator.StartPathfinding);
                bIsThreadLocked = true;
                thread.Start();
            }
        }

        public void PathAcquired(Stack<Vector3> path, PathRequest request, List<Vector3> indexes) {
            request.CallbackAction(path);
            foreach (Vector3 index in indexes) {
                int x = (int)index.x;
                int z = (int)index.z;
                PathfinderGrid[x,z].Data = new AStarData();
                PathfinderGrid[x,z].HeapIndex = 0;
            }
            bIsThreadLocked = false;
            Tick();
        }

        public void SetGrid(int sizeX, int sizeZ) {
            PathfinderGrid = new PathfinderNode[sizeX, sizeZ];
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    PathfinderGrid[x, z] = new PathfinderNode(new Vector3(x, 0, z));
                }
            }
            const float rayDistance = 0.5f;
            Ray ray;
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    ray = new Ray(new Vector3(x, 0, z), Vector3.forward);
                    if (!Physics.Raycast(ray, rayDistance)) {
                        PathfinderGrid[x, z].AddNeighbor(PathfinderGrid[x, z + 1]);
                    }
                    ray.direction = Vector3.back;
                    if (!Physics.Raycast(ray, rayDistance)) {
                        PathfinderGrid[x, z].AddNeighbor(PathfinderGrid[x, z - 1]);
                    }
                    ray.direction = Vector3.right;
                    if (!Physics.Raycast(ray, rayDistance)) {
                        PathfinderGrid[x, z].AddNeighbor(PathfinderGrid[x + 1, z]);
                    }
                    ray.direction = Vector3.left;
                    if (!Physics.Raycast(ray, rayDistance)) {
                        PathfinderGrid[x, z].AddNeighbor(PathfinderGrid[x - 1, z]);
                    }
                }
            }
        }

        public void NewPathRequest(Vector3 startingPosition, Vector3 endingPosition, Action<Stack<Vector3>> callback) {
            incomingRequests.Enqueue(new PathRequest(startingPosition, endingPosition, callback));
            Tick();
        }
    }
}