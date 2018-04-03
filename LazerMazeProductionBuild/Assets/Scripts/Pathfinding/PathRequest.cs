using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathfinding {

    /**
     * Holds the data needed for a path calculation , along with the delegate method to return the path to the caller
     */
    public class PathRequest {
        public PathfinderNode StartingPosition { get; private set; }
        public PathfinderNode TargetPosition { get; private set; }

        public delegate void functionToCall(Stack<Vector3> pathCalculated);

        public functionToCall FunctionToCall { get; private set; }

        public PathRequest(PathfinderNode startingPosition, PathfinderNode targetPosition, functionToCall function) {
            StartingPosition = startingPosition;
            TargetPosition = targetPosition;
            FunctionToCall = function;
        }
    }
}
