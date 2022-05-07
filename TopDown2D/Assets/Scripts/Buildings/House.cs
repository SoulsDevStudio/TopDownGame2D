using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Color startAlpha;
    [SerializeField] private Color endAlpha;
    [SerializeField] private float timeAmount;

    [Header("Components")]
    [SerializeField] private GameObject houseColl;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private Transform point;

    private PlayerAnim anim;
    private PlayerInventary player;
    private float timeCount;
    private bool isBegining;

    void Start()
    {
        player = FindObjectOfType<PlayerInventary>();
        anim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && player.totalWood >= woodAmount)
        {
            isBegining = true;
            anim.OnHammeringStarted();
            houseSprite.color = startAlpha;
            player.transform.position = point.position;
            player.totalWood -= woodAmount;
        }

        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeAmount)
            {
                houseSprite.color = endAlpha;
                anim.OnHammeringEnded();
                houseColl.SetActive(true);
            }
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
