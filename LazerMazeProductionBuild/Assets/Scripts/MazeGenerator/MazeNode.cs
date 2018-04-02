﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.MazeGenerator {

    /**
     * Holds data to be consumed my the MazeGenerator
     */
    public class MazeNode {
        private List<WallNode> walls = new List<WallNode>();

        public List<WallNode> Walls {
            get { return walls; }
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

        public void RemoveWall(WallNode toRemove) {
            walls.Remove(toRemove);
        }

        public void RemoveWall(int orientation) {
            walls.Remove(walls.FirstOrDefault(wall => (int)wall.Orientation == orientation));
        }
    }
}
