using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{


    [SerializeField]
    [Tooltip("Points added to store at enemy destroy")]
    private int pointsAmount;

    private float retardoPlayDestruction = 0.6f;

    public UnityEvent scoreChange;

    private void Awake()
    {
        Life life = GetComponent<Life>();//El primer Life se puede cambiar por *var
        life.onDeath.AddListener(DestroyEnemy);
    }
    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }
    private void DestroyEnemy()
    {
        scoreChange.Invoke();
        ScoreUI.SharedInstance.ChangeScore(pointsAmount);
        scoreChange.Invoke();
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("PlayDie");
        Collider body = GetComponent<Collider>();
        body.enabled = false;
        Invoke("PlayDestruction", retardoPlayDestruction);
        Destroy(gameObject, 2);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }

    private void PlayDestruction()
    {
        ParticleSystem xplosion = GetComponentInChildren<ParticleSystem>();
        xplosion.Play();
    }

    private void OnDestroy()
    {
        Life life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);//For not incurring in a memory leak remove the listener at GameObject destruction 
    }
}
