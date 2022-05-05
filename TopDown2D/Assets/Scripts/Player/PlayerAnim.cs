using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player;
    private Animator anim;

    private Casting cast;
    
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
}
