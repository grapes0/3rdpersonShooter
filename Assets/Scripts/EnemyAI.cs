using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool patrolMode;
    public float artifactAttackDistance;
    public float artifactDamage;
    public float viewAngle;
    public float damage = 30;
    public List<Transform> patrolPoints;

    private PlayerController _player;
    private Artifact _artifact;
    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;
    private CharacterController _characterController;
    private EnemyHealth _enemyHealth;
    private float _distanceToDestination;
    private bool _playerNoticed;

    // Start is called before the first frame update
    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _artifact = FindObjectOfType<Artifact>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _characterController = _player.GetComponent<CharacterController>();
        _enemyHealth = GetComponent<EnemyHealth>();
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
            _navMeshAgent.destination = _artifact.transform.position;
            if(_enemyHealth.health < _enemyHealth.maxHealth)
            {
                _playerNoticed = true;
                artifactAttackDistance = 0; //Это чтобы моб не мог атаковать артифакт пока следует за игроком
                ChaseUpdate();
                AttackUpdate(); 
            }
            else if (Vector3.Distance(transform.position, _artifact.transform.position) <= artifactAttackDistance)
            {
                _artifact.TakeDamage(artifactDamage * Time.deltaTime);
            }
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
        var direction = _player.transform.position - transform.position; //Направление вектора определяется вычитанием координат источника луча из координат конечного обЪекта
        _playerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit; //Переменная с рейкастом, хранит информацию от обЪекте с которым встретится рейкаст
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit)) //Проверяем если рэйкаст наткнулся на какой-то обЪект
            {
                if (hit.collider.gameObject == _player.gameObject)
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
            _navMeshAgent.destination = _player.transform.position;
        }
    }
    private void AttackUpdate()
    {
        if (_playerNoticed == true && Vector3.Distance(transform.position, _player.transform.position) <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.TakeDamage(damage * Time.deltaTime);
        }
    }
}
