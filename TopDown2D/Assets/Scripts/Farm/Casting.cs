using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{

    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int percentage;

    private PlayerInventary player;

    void Start()
    {
        player = FindObjectOfType<PlayerInventary>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            OnCasting();
        }
    }

    void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= percentage)
        {

        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
