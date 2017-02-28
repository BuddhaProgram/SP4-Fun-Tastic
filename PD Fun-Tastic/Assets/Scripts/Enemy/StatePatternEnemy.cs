using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatePatternEnemy : MonoBehaviour
{
    public float searchingTurnSpeed = 240f;
    public float searchingDuration = 2f;
    public float sightRange = 8f;
    public float enemyHP = 100;
    public float enemyPatrolSpeed = 100;
	public float enemyChaseSpeed = 100;
    public float enemyDamage = 100;
    public float enemyAccelerationSpeed = 100;
	[HideInInspector]
	public Transform[] wayPoints;
	public GameObject wayPointRef;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;

	public Rigidbody rb;

    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
	[HideInInspector]
	public IdleState idleState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public AttackState attackState;
	[HideInInspector]
	public RunState runState;
    [HideInInspector]
    public Transform attackTarget;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
	[HideInInspector]
	public Rigidbody rigibody;

    private void Awake()
    {
        chaseState = new ChaseState(this);
		idleState = new IdleState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);
        attackState = new AttackState(this);
		runState = new RunState (this);
        navMeshAgent = GetComponent<NavMeshAgent>();
		rigibody = GetComponent<Rigidbody> ();

		wayPoints = wayPointRef.GetComponentsInChildren<Transform> ();
    }

    // Use this for initialization
    void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        DestroyEnemy();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    
    private void DestroyEnemy()
    {
        if(this.GetComponent<Health>().health <= 0)
        {
            gameObject.GetComponent<EnemyReductionChecker>().EnemyRequirementChecker();
            Destroy(gameObject);
        }
    }
}