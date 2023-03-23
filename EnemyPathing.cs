using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointsIndex = 0;

    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointsIndex <= waypoints.Count - 1)
        {
            // Where we want to go to
            var targetPosition = waypoints[waypointsIndex].transform.position;
            // Speed getting there
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            // Check if we've reached the target
            if (transform.position == targetPosition)
            {
                waypointsIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
