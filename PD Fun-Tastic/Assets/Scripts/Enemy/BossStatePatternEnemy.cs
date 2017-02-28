using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BossStatePatternEnemy : MonoBehaviour
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

	public float fireRate;
	public GameObject projectile;
	public float fieldOfView;
	public List<GameObject> projectileSpawn;
	public GameObject target;
	List<GameObject> m_lastProjectile = new List<GameObject>();
	public float fireTimer = 0.0f;
	[HideInInspector]
	public int attRan = 0;

    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public BossIEnemyState currentState;
	[HideInInspector]
	public BossIdleState idleState;
    [HideInInspector]
    public BossChaseState chaseState;
    [HideInInspector]
    public BossAlertState alertState;
    [HideInInspector]
    public BossPatrolState patrolState;
    [HideInInspector]
    public BossAttackState attackState;
    [HideInInspector]
    public Transform attackTarget;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
	[HideInInspector]
	public Rigidbody rigibody;

    private void Awake()
    {
        chaseState = new BossChaseState(this);
		idleState = new BossIdleState(this);
        alertState = new BossAlertState(this);
        patrolState = new BossPatrolState(this);
        attackState = new BossAttackState(this);
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

	public void SpawnProjectile()
	{
		if (!projectile)
		{
			return;
		}
		for (int i = 0; i <projectileSpawn.Count; i++)
		{
			if (projectileSpawn [i])
			{
				GameObject proj = Instantiate (projectile, projectileSpawn [i].transform.position, Quaternion.Euler (projectileSpawn [i].transform.forward)) as GameObject;
				proj.GetComponent<BaseProjectile>().FireProjectile (projectileSpawn [i], target, enemyDamage);

				m_lastProjectile.Add (proj);
			}
		}
	}

    private void OnTriggerEnter(Collider other)
    {
		attRan = Random.Range (1, 3);
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