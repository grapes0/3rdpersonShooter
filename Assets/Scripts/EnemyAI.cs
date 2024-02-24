using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public PlayerController player;
    public float viewAngle;
    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;
    private float _distanceToDestination;
    private bool _playerNoticed;

    void PickNewPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    void PatrolUpdate()
    {
        if (!_playerNoticed)
        {
            _distanceToDestination = _navMeshAgent.remainingDistance;
            if (_distanceToDestination == 0)
            {
                PickNewPoint();
            }

        }
    }
    void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position; //Направление вектора определяется вычитанием координат источника луча из координат конечного обЪекта
        _playerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit; //Переменная с рейкастом, хранит информацию от обЪекте с которым встретится рейкаст
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit)) //Проверяем если рэйкаст наткнулся на какой-то обЪект
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _playerNoticed = true;
                }

            }
        }
    }
    void ChaseUpdate()
    {
        if (_playerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }
}
