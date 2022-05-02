using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private SpriteRenderer spriteRender;

    [SerializeField] private int digAmount;

    private int initialDigAmount;

    private void Start()
    {
        initialDigAmount = digAmount;
    }

    public void OnHit()
    {
        digAmount--;

        if(digAmount <= 0)
        {
            spriteRender.sprite = hole;
        }

        //if (digAmount <= 0)
        //{
        //    spriteRender.sprite = carrot;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();

        }
    }

}
