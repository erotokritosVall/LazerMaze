using Assets.Scripts.Pathfinding;
using UnityEngine;

namespace Assets.Scripts.MazeGrid {

    /**
     * Helper function to convert MazeNodes to PathfinderNode
     */
    public static class MazeNodeToPathfinderNode {
        public static PathfinderNode[,] Convert(MazeNode[,] mazeNodeGrid) {
            int sizeX = mazeNodeGrid.GetLength(0);
            int sizeZ = mazeNodeGrid.GetLength(1);
            PathfinderNode[,] pathfinderGrid = new PathfinderNode[sizeX, sizeZ];
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    Vector3 position = new Vector3(x, 0, z);
                    pathfinderGrid[x, z] = new PathfinderNode(position);
                    foreach(WallNode wall in mazeNodeGrid[x, z].Walls) {
                        MazeNode neighbor = wall.Neighbor;
                        if (neighbor != null) {
                            int neighborXPos = 0;
                            int neighborZPos = 0;
                            for (int i = 0; i < sizeX; i++) {
                                for (int j = 0; j < sizeZ; j++) {
                                    if (mazeNodeGrid[i, j].Equals(neighbor)) {
                                        neighborXPos = i;
                                        neighborZPos = j;
                                        break;
                                    }
                                }
                            }
                            pathfinderGrid[x, z].AddNeighbor(pathfinderGrid[neighborXPos, neighborZPos]);
                        }
                    }
                }
            }
            return pathfinderGrid;
        }
    }
}
