using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventary : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int _totalWood;
    [SerializeField] private int _totalCarrot;
    [SerializeField] private float _currentWater;
    
    [Header("Limits")]
    [SerializeField] private float _waterLimit;
    [SerializeField] private float _carrotLimit;
    [SerializeField] private float _woodLimit;

    public int totalWood { get => _totalWood; set => _totalWood = value; }
    public int TotalCarrot { get => _totalCarrot; set => _totalCarrot = value; }
    public float currentWater { get => _currentWater; set => _currentWater = value; }

    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float CarrotLimit { get => _carrotLimit; set => _carrotLimit = value; }
    public float WoodLimit { get => _woodLimit; set => _woodLimit = value; }

    public void WaterLimit(float water)
    {
        if(currentWater < waterLimit)
        {
            currentWater += water;
        }
        
    }

}
