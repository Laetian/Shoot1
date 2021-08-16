using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]
public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }

    public EnemyState currentState;

    private Sight _sight;

    private Transform baseTransform;
    [SerializeField]
    private float playerAttackDistance;
    [SerializeField]
    private float baseAttackDistance;

    private NavMeshAgent agent;

    private Animator animator;

    private void Awake()
    {
        _sight = GetComponent<Sight>();
        baseTransform = GameObject.Find("Base").transform; //Find by name
        //baseTransform = GameObject.FindWithTag("Base").transform; // Can only recognize 1 object, problems if more than one exists
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
    }
    private void Update()
    {

        switch (currentState)
        {
            case EnemyState.GoToBase:
                GoToBase();
                break;
            case EnemyState.AttackBase:
                AttackBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
            //default:
                //break;
        }

        /*
        if(currentState == EnemyState.GoToBase)
        {
            //TODO: Go to base
        }
        else if (currentState == EnemyState.AttackBase)
        {
            //TODO: Attack base
        }
        else if ( currentState == EnemyState.ChasePlayer)
        {
            //TODO: Chase player
        }
        else if ( currentState == EnemyState.AttackPlayer)
        {
            //TODO: Attack player
        }*/
    }

    void GoToBase()
    {
        animator.SetBool("ShotBullet", false);
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);

        if (_sight.detectedTarget != null)
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }
    void AttackBase()
    {
        agent.isStopped = true;
        LookAt(baseTransform.position);
        shootTarget();
    }
    void ChasePlayer()
    {
        animator.SetBool("ShotBullet", false);
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.isStopped = false;
        agent.SetDestination(_sight.detectedTarget.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer()
    {
        agent.isStopped = true;
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookAt(_sight.detectedTarget.transform.position);
        shootTarget();
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.5)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
    private float lastShootTime;
    [SerializeField]
    private float shootRate;
    void shootTarget()
    {
        if (Time.timeScale>0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < shootRate)
            {
                return;
            }
            lastShootTime = Time.time;
            animator.SetBool("ShotBullet", true);
            var bullet = BulletPool.SharedInstance.GetFirstPooledObject();
            bullet.layer = LayerMask.NameToLayer("EnemyBullet");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
    void LookAt(Vector3 targetPos)
    {
        Vector3 directionToLook = Vector3.Normalize(targetPos - transform.position);
        directionToLook.y = 0;
        transform.parent.forward = directionToLook;
    }
}