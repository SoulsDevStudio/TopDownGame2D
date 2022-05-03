using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventary : MonoBehaviour
{
    [SerializeField] private int _totalWood;
    [SerializeField] private int _totalCarrot;
    [SerializeField] private float _currentWater;
    [SerializeField] private float _waterLimit;

    public int totalWood { get => _totalWood; set => _totalWood = value; }
    public float currentWater { get => _currentWater; set => _currentWater = value; }
    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public int TotalCarrot { get => _totalCarrot; set => _totalCarrot = value; }

    public void WaterLimit(float water)
    {
        if(currentWater < waterLimit)
        {
            currentWater += water;
        }
        
    }

}
