using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Pathfinding {

    /**
     * Holds the data needed for a path calculation , along with the delegate method to return the path to the caller
     */
    public class PathRequest {
        public Vector3 StartingPosition { get; private set; }
        public Vector3 TargetPosition { get; private set; }
        public Action<Stack<Vector3>> CallbackAction { get; private set; }

        public PathRequest(Vector3 startingPosition, Vector3 targetPosition, Action<Stack<Vector3>> callback) {
            StartingPosition = startingPosition;
            TargetPosition = targetPosition;
            CallbackAction = callback;
        }
    }
}
