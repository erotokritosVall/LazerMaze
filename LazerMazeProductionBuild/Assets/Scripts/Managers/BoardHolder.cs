using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Pathfinding;
using Assets.Scripts.MazeGrid;
using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Class that spawns the board and holds the pathfinder grid
     */
    public class BoardHolder : MonoBehaviour {
        private int sizeX;
        private int sizeZ;
        [SerializeField]
        private GameObject floorTilePrefab;
        [SerializeField]
        private GameObject wallTilePrefab;
        public PathfinderNode[,] PathfinderGrid { get; private set; }

        private void Awake() {
            sizeX = sizeZ = 50;
            SetupLevel();
        }

        private void SetupLevel() {
            MazeGenerator generator = new MazeGenerator(sizeX, sizeZ);
            MazeNode[,] mazeGrid = generator.Generate();
            SpawnTiles(mazeGrid);
            PathfinderGrid = MazeNodeToPathfinderNode.Convert(mazeGrid);
        }

        private void SpawnTiles(MazeNode[,] grid) {
            const float spawnOffset = 0.5f;
            const float wallYPos = 0.2f;
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    Vector3 spawnPosition = new Vector3(x, 0, z);
                    Transform spawnedTile = Instantiate(floorTilePrefab, spawnPosition, Quaternion.identity, transform).transform;
                    foreach(WallNode wall in grid[x, z].Walls) {
                        Vector3 wallSpawnPosition;
                        Quaternion wallSpawnRotation = Quaternion.identity;
                        switch (wall.Orientation) {                     
                            case WallOrientation.N:
                            wallSpawnPosition = new Vector3(x, wallYPos, z + spawnOffset);
                            wallSpawnRotation = Quaternion.Euler(0, 90, 0);
                            break;

                            case WallOrientation.S:
                            wallSpawnPosition = new Vector3(x, wallYPos, z - spawnOffset);
                            wallSpawnRotation = Quaternion.Euler(0, 90, 0);
                            break;

                            case WallOrientation.E:
                            wallSpawnPosition = new Vector3(x + spawnOffset, wallYPos, z);
                            break;

                            default:
                            wallSpawnPosition = new Vector3(x - spawnOffset, wallYPos, z);
                            break;
                        }
                        Instantiate(wallTilePrefab, wallSpawnPosition, wallSpawnRotation, spawnedTile);
                    }
                }
            }
        }

    }
}
