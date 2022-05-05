using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{

    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int percentage;
    [SerializeField] private GameObject fishPrefab;

    private PlayerInventary player;
    private PlayerAnim playerAnim;

    void Awake()
    {
        player = FindObjectOfType<PlayerInventary>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= percentage)
        {
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-2f,-1f),0,0), Quaternion.identity);
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
