using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalDrop;

    [SerializeField] private ParticleSystem leafs;

    private bool isCut;

    public void OnHit() 
    {
        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();

        if(treeHealth <= 0)
        {
            totalDrop = Random.Range(1,5); 
            for (int i = 0; i < totalDrop; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }
            
            anim.SetTrigger("cut");

            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
