using System.Collections.Generic;

namespace Assets.Scripts.MazeGrid {

    /**
     * Generates wall positions so the spawner can instantiate a maze
     */

    public class MazeGenerator {
        private int sizeX;
        private int sizeZ;
        private MazeNode[,] grid;

        public MazeGenerator(int sizeX, int sizeZ) {
            this.sizeX = sizeX;
            this.sizeZ = sizeZ;
            grid = new MazeNode[sizeX, sizeZ];
        }

        private void CreateGrid() {
            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeZ; j++) {
                    grid[i, j] = new MazeNode();
                }
            }
        }
    
        private void AddWallNeighbors() {
            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeZ; j++) {
                    foreach (WallNode wall in grid[i, j].Walls) {
                        switch (wall.Orientation) {
                            case WallOrientation.N:
                            if (j + 1 < sizeZ) {
                                wall.Neighbor = grid[i, j + 1];
                            }
                            break;

                            case WallOrientation.S:
                            if (j - 1 >= 0) {
                                wall.Neighbor = grid[i, j - 1];
                            }
                            break;

                            case WallOrientation.E:
                            if (i + 1 < sizeX) {
                                wall.Neighbor = grid[i + 1, j];
                            }
                            break;

                            default:
                            if (i - 1 >= 0) {
                                wall.Neighbor = grid[i - 1, j];
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void GenerateMaze() {
            MazeNode startingNode = grid[0, 0];
            List<WallNode> openSet = new List<WallNode>();
            HashSet<MazeNode> closedSet = new HashSet<MazeNode>();
            openSet.AddRange(startingNode.Walls);
            closedSet.Add(startingNode);
            while(openSet.Count != 0) {
                int randomIndex = UnityEngine.Random.Range(0, openSet.Count);
                WallNode currentWall = openSet[randomIndex];
                MazeNode neighborOfCurrentWall = currentWall.Neighbor;
                if (neighborOfCurrentWall != null && !closedSet.Contains(neighborOfCurrentWall)) {
                    currentWall.Parent.RemoveWall(currentWall);
                    currentWall.Parent.AddNeighbor(neighborOfCurrentWall);
                    neighborOfCurrentWall.AddNeighbor(currentWall.Parent);
                    int oppositeWallToRemove = -(int)currentWall.Orientation;
                    neighborOfCurrentWall.RemoveWall(oppositeWallToRemove);
                    openSet.AddRange(neighborOfCurrentWall.Walls);
                    closedSet.Add(neighborOfCurrentWall);
                }
                openSet.Remove(currentWall);
            }
        }

        private void CleanupDuplicates() {
            foreach (MazeNode currentNode in grid) {
                foreach (WallNode currentWall in currentNode.Walls) {
                    MazeNode wallNeighbor = currentWall.Neighbor;
                    if (wallNeighbor != null) {
                       int oppositeWall = -(int)currentWall.Orientation;
                       wallNeighbor.RemoveWall(oppositeWall);
                    }
                }
            }
        }

        public MazeNode[,] Generate() {
            CreateGrid();
            AddWallNeighbors();
            GenerateMaze();
            CleanupDuplicates();
            return grid;
        }
    }
}
