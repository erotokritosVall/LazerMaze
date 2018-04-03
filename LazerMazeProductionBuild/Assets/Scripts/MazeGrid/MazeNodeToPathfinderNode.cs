using Assets.Scripts.Pathfinding;
using UnityEngine;

namespace Assets.Scripts.MazeGrid {

    /**
     * Helper class to convert MazeNodes to PathfinderNode
     */
    public class MazeNodeToPathfinderNode {
        private int sizeX;
        private int sizeZ;
        PathfinderNode[,] pathfinderGrid;

        public MazeNodeToPathfinderNode(int sizeX, int sizeZ) {
            this.sizeX = sizeX;
            this.sizeZ = sizeZ;
            pathfinderGrid = new PathfinderNode[sizeX, sizeZ];
            InitialiseGrid();
        }

        private void InitialiseGrid() {
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    Vector3 gridPosition = new Vector3(x, 0, z);
                    pathfinderGrid[x, z] = new PathfinderNode(gridPosition);
                }
            }
        }

        public PathfinderNode[,] Convert(MazeNode[,] mazeNodeGrid) {
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    foreach(MazeNode neighbor in mazeNodeGrid[x, z].NeighborsForPathfinding) {
                        if (x - 1 >= 0) {
                            if (mazeNodeGrid[x - 1, z].Equals(neighbor)) {
                                pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x - 1, z]);
                            }
                        }
                       if (x + 1 < sizeX) {
                             if (mazeNodeGrid[x + 1, z].Equals(neighbor)) {
                                pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x + 1, z]);
                            }
                        }
                        if (z - 1 >= 0) {
                            if (mazeNodeGrid[x, z - 1].Equals(neighbor)) {
                                pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x, z - 1]);
                            }
                        }
                        if (z + 1 < sizeZ) {
                            if (mazeNodeGrid[x, z + 1].Equals(neighbor)) {
                                pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[x, z + 1]);
                            }
                        }
                    }
                }
            }
            return pathfinderGrid;
        }
    }
}
