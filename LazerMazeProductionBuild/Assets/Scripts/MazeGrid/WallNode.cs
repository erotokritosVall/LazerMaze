namespace Assets.Scripts.MazeGrid {

    /**
     * Holds wall data to be consumed by the MazeNode and MazeGenerator
     */
    public class WallNode {

        public MazeNode Neighbor { get; set; }
        public WallOrientation Orientation { get; private set; }
        public MazeNode Parent { get; private set; }

        public WallNode(WallOrientation orientation, MazeNode parent) {
            Orientation = orientation;
            Parent = parent;
            Neighbor = null;
        }
    }

    //Opposite numbers (1, -1) , (2, -2) help in removing opposing walls in adjucent tiles so connections(paths) can be 
    //easily created. See RemoveWall(int orientation) func in MazeNode for a better understanding
    public enum WallOrientation {
        N = 1,
        S = -1,
        E = 2,
        W = -2
    }
}