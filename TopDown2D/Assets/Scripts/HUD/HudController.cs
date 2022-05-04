using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Image waterUI;
    [SerializeField] private Image woodUI;
    [SerializeField] private Image carrotUI;

    private PlayerInventary playerInventary;

    private void Awake()
    {
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
    }
}
