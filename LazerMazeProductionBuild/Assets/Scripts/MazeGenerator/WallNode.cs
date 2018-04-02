using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.MazeGenerator {

    /**
     * Holds wall data to be consumed by the MazeNode
     */
    public class WallNode {
        public WallOrientation Orientation { get; private set; }
        public MazeNode Parent { get; private set; }
        public MazeNode Neighbor { get; set; }

        public WallNode(WallOrientation orientation, MazeNode parent) {
            this.Orientation = orientation;
            this.Parent = parent;
            Neighbor = null;
        }
    }

    public enum WallOrientation {
        N = 1,
        S = -1,
        E = 2,
        W = -2
    }
}