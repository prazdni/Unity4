using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Unity4.Lesson8
{
    public class MoveEnemy : IExecute
    {
        private List<Vector3> _waypoints;
        private NavMeshAgent _agent;
        
        public MoveEnemy(List<Vector3> waypoints, NavMeshAgent agent)
        {
            _agent = agent;
            _waypoints = waypoints;
            _agent.SetDestination(_waypoints[Random.Range(0, _waypoints.Count)]);
        }

        public void Execute(float deltaTime)
        {
            if (_agent.remainingDistance < _agent.stoppingDistance)
            {
                var currentWaypointIndex = Random.Range(0, _waypoints.Count);
                _agent.SetDestination(_waypoints[currentWaypointIndex]);
            }
        }
    }
}