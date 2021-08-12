using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{


    [SerializeField]
    [Tooltip("Puntos que se suman al destruir al enemigo")]
    private int pointsAmount;
    
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
        Invoke("PlayDestruction", 0.6f);
        Destroy(gameObject, 2);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }

    void PlayDestruction()
    {
        ParticleSystem xplosion = GetComponentInChildren<ParticleSystem>();
        xplosion.Play();
    }

    private void OnDestroy()
    {
        Life life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);//Eliminar el listener al eliminar el objeto para que no se quede un "memory leak"
    }
}
