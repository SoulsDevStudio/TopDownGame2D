using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSfx;
    [SerializeField] private AudioClip carrotSfx;

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
    private bool plantedCarrot;
    private bool player;

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

            if (currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSfx);
                spriteRender.sprite = carrot;

                plantedCarrot = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && plantedCarrot && player)
            {
                audioSource.PlayOneShot(carrotSfx);
                playerInventary.TotalCarrot++;
                spriteRender.sprite = hole;
                currentWater = 0f;
                plantedCarrot = false;
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

        if (collision.CompareTag("Player"))
        {
            player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }

        if (collision.CompareTag("Player"))
        {
            player = false;
        }
    }

}
