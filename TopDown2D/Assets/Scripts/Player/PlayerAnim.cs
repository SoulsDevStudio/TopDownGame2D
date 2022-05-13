using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    private Player player;
    private Animator anim;

    private Casting cast;

    private bool isHitting;

    [SerializeField] private float timeCount;
    private float recoveryTime = 2f;
    
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    
    void Update()
    {
        OnMove();
        OnRun();

        if (isHitting)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
        

    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
            
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.IsCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if (player.IsDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if (player.IsWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void OnRun() 
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position,radius,enemyLayer);

        if(hit != null)
        {

        }
    }

    #endregion
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }
    
    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
        player.isPaused = true;
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
        player.isPaused = false;
    }

    public void OnHit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("isHit");
            isHitting = true;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
