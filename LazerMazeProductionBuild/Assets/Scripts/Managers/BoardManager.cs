using Assets.Scripts.Pathfinding;
using Assets.Scripts.MazeGrid;
using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Responsible for interacting with the maze generator and spawning the maze(floor and walls)
     */
    public class BoardManager : MonoBehaviour {

        [SerializeField]
        private GameObject floorTilePrefab;
        [SerializeField]
        private GameObject wallTilePrefab;

        public static BoardManager Instance { get; private set; }
        public int SizeX { get; private set; }
        public int SizeZ { get; private set; }

        private BoardManager() { }

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
            else if (Instance != this) {
                Destroy(this);
            }
            SizeX = SizeZ = 15;
        }

        private void Start() {
           SetupLevel();
        }

        private void SetupLevel() {
            MazeGenerator generator = new MazeGenerator(SizeX, SizeZ);
            MazeNode[,] mazeGrid = generator.Generate();
            SpawnTiles(mazeGrid);
            PathfindingManager.Instance.SetGrid(SizeX, SizeZ);
        }

        private void SpawnTiles(MazeNode[,] grid) {
            const float spawnOffset = 0.5f;
            for (int x = 0; x < SizeX; x++) {
                for (int z = 0; z < SizeZ; z++) {
                    Vector3 floorSpawnPosition = new Vector3(x, -0.5f, z);
                    Transform spawnedTile = Instantiate(floorTilePrefab, floorSpawnPosition, Quaternion.identity, transform).transform;
                    foreach(WallNode wall in grid[x, z].Walls) {
                        Vector3 wallSpawnPosition = new Vector3(x , -0.2f, z);
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
