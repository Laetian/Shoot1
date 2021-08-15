using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sight))]
public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }

    public EnemyState currentState;

    private Sight _sight;

    public Transform baseTransform;

    public float baseAttackDistance, playerAttackDistance;

    private void Awake()
    {
        _sight = GetComponent<Sight>();
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
        print("Ir a la base");
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
        print("Attack the base");
    }
    void ChasePlayer()
    {
        print("Chase the player");
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer()
    {
        print("Attack to the player");
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.3)
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
}