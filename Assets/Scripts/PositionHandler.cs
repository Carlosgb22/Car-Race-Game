using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    public List<CarLapCounter> carLapCounters = new List<CarLapCounter>();
    // Start is called before the first frame update
    void Start()
    {
        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();
        carLapCounters = carLapCounterArray.ToList<CarLapCounter>();
        foreach (CarLapCounter lapCounters in carLapCounters)
        {
            lapCounters.OnPassCheckPoint += OnPassCheckPoint;
        }
    }
    void OnPassCheckPoint(CarLapCounter carLapCounter)
    {
        carLapCounters = carLapCounters.OrderByDescending(s => s.GetNumberOfCheckPointsPassed())
        .ThenBy(s => s.GetTimeAtLastCheckPoint()).ToList();
        int carPosition = carLapCounters.IndexOf(carLapCounter) + 1;
        carLapCounter.SetCarPosition(carPosition);
    }
}