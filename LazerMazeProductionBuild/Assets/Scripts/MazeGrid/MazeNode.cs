using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assets.Scripts.MazeGrid {

    /**
     * Holds data to be consumed my the MazeGenerator
     */

    public class MazeNode {

        private List<WallNode> walls = new List<WallNode>();
        public ReadOnlyCollection<WallNode> Walls {
            get { return new ReadOnlyCollection<WallNode>(walls); }
        }

        private void InitialiseWalls() {
            for(int i = 1; i < 3; i++) {
                walls.Add(new WallNode((WallOrientation)i, this));
                walls.Add(new WallNode((WallOrientation)(-i), this));
            }
        }

        public MazeNode() {
            InitialiseWalls();
        }

        //Two overloaded remove wall functions , one for when we already have the wall we want to remove,
        //the other for when we know only the orientation of the wall that should be removed. 
        //Helps in creating connections(paths) between nodes faster.
        public void RemoveWall(WallNode toRemove) {
            walls.Remove(toRemove);
        }

        public void RemoveWall(int orientation) {
            walls.Remove(walls.First(wall => wall.Orientation.Equals((WallOrientation)orientation)));
        }
    }
}
