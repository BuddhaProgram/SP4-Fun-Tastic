using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RangeStatePatternEnemy : MonoBehaviour
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
    public Transform chaseTarget;
    [HideInInspector]
	public RangeIEnemyState currentState;
    [HideInInspector]
	public RangeChaseState chaseState;
    [HideInInspector]
	public RangeAlertState alertState;
    [HideInInspector]
	public RangePatrolState patrolState;
    [HideInInspector]
	public RangeAttackState attackState;
    [HideInInspector]
    public Transform attackTarget;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
	[HideInInspector]
	public Rigidbody rigibody;

    private void Awake()
    {
		chaseState = new RangeChaseState(this);
		alertState = new RangeAlertState(this);
		patrolState = new RangePatrolState(this);
		attackState = new RangeAttackState(this);
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