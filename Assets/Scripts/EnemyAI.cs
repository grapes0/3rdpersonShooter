using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool patrolMode;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;
    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;
    private CharacterController _characterController;
    private float _distanceToDestination;
    private bool _playerNoticed;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _characterController = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(patrolMode == true)
        {
            NoticePlayerUpdate();
            ChaseUpdate();
            PatrolUpdate();
            AttackUpdate();
        }
        else
        {
            _playerNoticed = true;
            ChaseUpdate();
            AttackUpdate(); 
        }
    }

    private void PickNewPoint()
    {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (!_playerNoticed)
        {
            _distanceToDestination = _navMeshAgent.remainingDistance;
            if (_distanceToDestination <= _navMeshAgent.stoppingDistance)
            {
                PickNewPoint();
            }

        }
    }
    private void NoticePlayerUpdate()
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
    private void ChaseUpdate()
    {
        if (_playerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void AttackUpdate()
    {
        if (_playerNoticed == true && Vector3.Distance(transform.position, player.transform.position) <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.TakeDamage(damage * Time.deltaTime);
        }
    }
}
