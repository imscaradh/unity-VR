using UnityEngine;

using System.Collections.Generic;

public class PatrolPath : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    // Initial direction of this path
    public Direction direction = Direction.Right;

    public List<Transform> waypoints;

    // weather or not to connect start and end point togeter
    public bool closedPath = false;

    // current direction indicator
    private bool _goingRight;

    private int _currentIndex = 0;

    void Awake()
    {
        _goingRight = (direction == Direction.Right);
    }

    // property to get the current waypoint if it exists
    public Transform currentWaypoint
    {
        get
        {
            if (waypoints.Count > 0)
                return waypoints[_currentIndex];

            return null;
        }
    }

    // proerty to get the last waypoint if it exists
    public Transform lastWaypoint
    {
        get
        {
            if (waypoints.Count > 0)
                return waypoints[waypoints.Count - 1];

            return null;
        }
    }

    // adds a new waypoint
    public void AddWaypoint()
    {
        // create a new gameobject and call it waypoint 
        // note: this will not generate unique names.
        GameObject go = new GameObject("Waypoint " + waypoints.Count);
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;

        if (waypoints.Count > 0)
        {
            Vector3 direction = Vector3.forward;
            // get direction of last edge
            if (waypoints.Count > 1)
            {
                Vector3 from = waypoints[waypoints.Count - 2].position;
                Vector3 to = lastWaypoint.position;
                direction = (to - from).normalized;
            }

            go.transform.position = lastWaypoint.position + direction * 0.5f;
        }

        // Add a waypoint component to the gameobject and add it's reference to our list
        waypoints.Add(go.transform);
    }

    public void Next()
    {
        IncrementIndex();
    }

    // increment the index basd on closePath etc.
    void IncrementIndex()
    {
        if (!closedPath &&
                (_goingRight && _currentIndex == waypoints.Count - 1
                || !_goingRight && _currentIndex == 0))
        {
            _goingRight = !_goingRight;
        }

        if (_goingRight) _currentIndex++;
        else _currentIndex--;

        while (_currentIndex < 0)
            _currentIndex += waypoints.Count;

        _currentIndex %= waypoints.Count;
    }
		
   
}
