using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private SkeletonAnim anim;

    public float radius;
    public LayerMask layer;
    public float currentHealth;
    public Image healthBar;
    public float totalHealth;
    public bool isDead;
    
    private Player player;
    private bool detect;
    void Start()
    {
        currentHealth = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && detect)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                anim.PlayAnim(2);
            }
            else
            {
                anim.PlayAnim(1);
            }

            float posX = player.transform.position.x - transform.position.x;

            if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        
    }

    private void FixedUpdate()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D playerDetect = Physics2D.OverlapCircle(transform.position, radius, layer);

        if(playerDetect != null)
        {
            detect = true;
        }
        else
        {
            detect = false;
            anim.PlayAnim(0);
            agent.isStopped = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
