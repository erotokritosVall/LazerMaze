using System.Collections.Generic;
using System;
using System.Threading;
using Assets.Scripts.Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Responsible for handling , queueing and proccessing path requests
     */
    public class PathfindingManager : MonoBehaviour {
        private PathfinderNode[,] pathfinderGrid;
        private Queue<PathRequest> incomingRequests = new Queue<PathRequest>();
        public static PathfindingManager Instance { get; private set; }
        public bool bIsThreadLocked = false;
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
                PathCalculator pathCalculator = new PathCalculator(toProccess, pathfinderGrid);
                Thread thread = new Thread(pathCalculator.StartPathfinding);
                bIsThreadLocked = true;
                thread.Start();
            }
        }

        public void PathAcquired(Stack<Vector3> path, PathRequest request, List<Vector3> indexes) {
            request.CallbackAction.Invoke(path);
            foreach (Vector3 index in indexes) {
                pathfinderGrid[(int)index.x, (int)index.z].Data = new AStarData();
                pathfinderGrid[(int)index.x, (int)index.z].HeapIndex = 0;
            }
            bIsThreadLocked = false;
            Tick();
        }

        public void SetGrid(int sizeX, int sizeZ) {
            pathfinderGrid = new PathfinderNode[sizeX, sizeZ];
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    pathfinderGrid[x, z] = new PathfinderNode(new Vector3(x, 0, z));
                }
            }
            const float rayDistance = 0.5f;
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    Ray ray = new Ray(new Vector3(x, 0, z), Vector3.forward);
                    if (!Physics.Raycast(ray, rayDistance)) {
                        pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x, z + 1]);
                    }
                    ray.direction = Vector3.back;
                    if (!Physics.Raycast(ray, rayDistance)) {
                        pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x, z - 1]);
                    }
                    ray.direction = Vector3.right;
                    if (!Physics.Raycast(ray, rayDistance)) {
                        pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x + 1, z]);
                    }
                    ray.direction = Vector3.left;
                    if (!Physics.Raycast(ray, rayDistance)) {
                        pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x - 1, z]);
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