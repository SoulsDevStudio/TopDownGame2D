using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image waterUI;
    [SerializeField] private Image woodUI;
    [SerializeField] private Image carrotUI;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerInventary playerInventary;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        playerInventary = FindObjectOfType<PlayerInventary>();
    }

    void Start()
    {
        waterUI.fillAmount = 0f;
        woodUI.fillAmount = 0f;
        carrotUI.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUI.fillAmount = playerInventary.currentWater/ playerInventary.waterLimit;
        woodUI.fillAmount = playerInventary.totalWood/ playerInventary.WoodLimit;
        carrotUI.fillAmount = playerInventary.TotalCarrot/ playerInventary.CarrotLimit;

        

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.HandlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
