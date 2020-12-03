using UnityEngine;
using UnityEngine.AI;


public class WaypointMobs : MonoBehaviour
{
    #region Fields

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;

    private int _currentWaypointIndex;

    #endregion


    #region UnityMethods

    private void Start()
    {
        navMeshAgent.SetDestination(waypoints[Random.Range(0, waypoints.Length)].position);
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _currentWaypointIndex = Random.Range(0, waypoints.Length);
            navMeshAgent.SetDestination(waypoints[_currentWaypointIndex].position);
        }
    }

    #endregion
}
