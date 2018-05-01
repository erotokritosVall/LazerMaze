using Assets.Scripts.Pathfinding;
using Assets.Scripts.MazeGrid;
using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Responsible for interacting with the maze generator and spawning the maze(floor and walls)
     */
    public class BoardHolder : MonoBehaviour {
        private int sizeX;
        private int sizeZ;
        [SerializeField]
        private GameObject floorTilePrefab;
        [SerializeField]
        private GameObject wallTilePrefab;

        private void Awake() {
            sizeX = sizeZ = 15;
        }

        private void Start() {
           SetupLevel();
        }

        private void SetupLevel() {
            MazeGenerator generator = new MazeGenerator(sizeX, sizeZ);
            MazeNode[,] mazeGrid = generator.Generate();
            SpawnTiles(mazeGrid);
            PathfindingManager.Instance.SetGrid(sizeX, sizeZ);
        }

        private void SpawnTiles(MazeNode[,] grid) {
            const float spawnOffset = 0.5f;
            for (int x = 0; x < sizeX; x++) {
                for (int z = 0; z < sizeZ; z++) {
                    Vector3 floorSpawnPosition = new Vector3(x, -0.5f, z);
                    Transform spawnedTile = Instantiate(floorTilePrefab, floorSpawnPosition, Quaternion.identity, transform).transform;
                    foreach(WallNode wall in grid[x, z].Walls) {
                        Vector3 wallSpawnPosition = new Vector3(x , 0.0f, z);
                        Quaternion wallSpawnRotation = Quaternion.identity;
                        switch (wall.Orientation) {                     
                            case WallOrientation.N:
                            wallSpawnPosition.z += spawnOffset;
                            wallSpawnRotation = Quaternion.Euler(0, 90, 0);
                            break;

                            case WallOrientation.S:
                            wallSpawnPosition.z -= spawnOffset;
                            wallSpawnRotation = Quaternion.Euler(0, 90, 0);
                            break;

                            case WallOrientation.E:
                            wallSpawnPosition.x += spawnOffset;
                            break;

                            default:
                            wallSpawnPosition.x -= spawnOffset;
                            break;
                        }
                        Instantiate(wallTilePrefab, wallSpawnPosition, wallSpawnRotation, spawnedTile);
                    }
                }
            }
        }

        private void CleanLevel() {
            foreach(Transform child in transform) {
                Destroy(child.gameObject);
            }
        }
    }
}
