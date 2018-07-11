using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }
    public bool IsAttacked
    {
        get
        {
            return isAttacked;
        }
        set
        {
            isAttacked = value;
        }
    }
    public GameObject PlayerObj
    {
        get
        {
            return playerObj;
        }
        set
        {
            playerObj = value;
        }
    }
    public Vector3 _position;
    private GameObject playerObj;
    private bool isAttacked;
    private int hp;
    private int maxHp=100;
    private string _name;
    private int id;
    private string type;
    private RectTransform blood;
    private Animation anim;
    private NavMeshAgent navMeshAgent;
    private float toOther;
    private float attackDistance;
    private float range;
    //private bool isYield;
    private ParticleSystem effects;
    //private int count;//用来判断第一次被击中后，需要延迟一会再攻击；
    private float rotationSpeed=1f;
    private float coolingTime;
    private float coolTime;

    void Start()
    {
        _position = new Vector3(-79,0.1f,40);
        range = 15f;
        attackDistance = 5f;
        hp = maxHp;
        blood = transform.FindChild("EnemyStatu/Panel/EnemyBloodStrip/EnemyBlood").GetComponent<RectTransform>();
        anim = GetComponent<Animation>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        effects = transform.FindChild("AuraActivateLight").GetComponent<ParticleSystem>();
        anim["touchHead"].speed = 2;
        playerObj = null;
        coolingTime = 0;
        coolTime = 2.5f;
       // isYield = false;
       // count = 0;
    }

    void Update()
    {
        coolingTime += Time.deltaTime;
        blood.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0.007f,hp*0.00192f);
        if ((transform.position-_position).magnitude>=range)
        {            
            if (playerObj!=null)
            {
                playerObj = null;//失去目标
                //StopAllCoroutines();
               // count = 0;
            }           
            navMeshAgent.SetDestination(_position);
        }
        if (playerObj!=null)
        {
             toOther = (playerObj.transform.position - transform.position).magnitude;
            playerBattle battle = playerObj.GetComponent<playerBattle>();
            if (toOther<=attackDistance)
            {
                navMeshAgent.ResetPath();
                //if (!isYield)
               // {
                    StartCoroutine(waitAttack(battle));
                   // isYield = true;
               // }
            }else
            {
                navMeshAgent.SetDestination(playerObj.transform.position);
                StopAllCoroutines();
               // isYield = false;
            }
        }else
        {
            if ((transform.position - _position).magnitude <= 1)
            {
                navMeshAgent.ResetPath();
            }
        }
        if (navMeshAgent.remainingDistance>3f)
        {
            anim.Play("run",PlayMode.StopSameLayer);
        }
        if (isAttacked)
        {
            anim.Play("touchHead",PlayMode.StopSameLayer);
            isAttacked = false;
        }
        anim.PlayQueued("idle01",QueueMode.CompleteOthers,PlayMode.StopSameLayer);
        if (hp<=0)
        {
            Destroy(this.gameObject);
        }

    }
    IEnumerator waitAttack(playerBattle battle)
    {
       
        //if (count==0)
        //{
        //    count = 1;
        //    yield return new WaitForSeconds(interval);           
        //}
        float dot = 0.5f;
        int _damage = 20;
        float _dot = 0;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 v = new Vector3(transform.position.x, playerObj.transform.position.y, transform.position.z);
        Vector3 _toOther = playerObj.transform.position - v;
        _dot = Vector3.Dot(forward, _toOther);
        if (_dot< dot * attackDistance)
        {
            transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(forward), Quaternion.LookRotation(playerObj.transform.position - transform.position), rotationSpeed * Time.deltaTime);
            
        }
        else
        {
            if (coolingTime>=coolTime)
            {
                coolingTime = 0;
                anim.Play("choice", PlayMode.StopAll);
                effects.Play();
                yield return new WaitForSeconds(0.3f);
                if (dot * attackDistance < _dot)
                {
                    battle.CurrntHp -= _damage;
                }
            }
            
        }      
        //StartCoroutine(waitAttack(interval, battle));
    }



	}

