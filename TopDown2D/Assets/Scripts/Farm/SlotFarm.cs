using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private SpriteRenderer spriteRender;

    [Header("Settings")]
    [SerializeField] private int digAmount;
    [SerializeField] private float waterAmount;
    [SerializeField] private bool detecting;

    private int initialDigAmount;

    private float currentWater;

    private bool dugHole;

    PlayerInventary playerInventary;

    private void Start()
    {
        playerInventary = FindObjectOfType<PlayerInventary>();

        initialDigAmount = digAmount;
    }

    private void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount)
            {
                spriteRender.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerInventary.TotalCarrot++;
                    spriteRender.sprite = hole;
                    currentWater = 0f;
                }
            }
        }
        
    }

    public void OnHit()
    {
        digAmount--;

        if(digAmount <= 0)
        {
            spriteRender.sprite = hole;
            dugHole = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();

        }

        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }
    }

}
