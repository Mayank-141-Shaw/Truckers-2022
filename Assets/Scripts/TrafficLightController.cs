using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{

    [SerializeField] private GameObject trafficLightRed;
    [SerializeField] private GameObject trafficLightGreen;
    [SerializeField] private GameObject pedLightRed;
    [SerializeField] private GameObject pedLightGreen;

    [SerializeField] private Material redLight;
    [SerializeField] private Material greenLight;
    [SerializeField] private Material noLight;

    public float trafficSignalTimeout;
    public float pedSignalTimeout;

    public int trafficNum;
    public int pedNum;

    
    void Start()
    {
        InvokeRepeating("ChangeTrafficSignalLight", trafficSignalTimeout, trafficSignalTimeout);
        InvokeRepeating("ChangePedSignalLight", pedSignalTimeout, pedSignalTimeout);
    }

    void ChangeTrafficSignalLight()
    {
        trafficNum = (trafficNum + 1) % 2;
        switch (trafficNum)
        {
            case 0: // red
                trafficLightRed.GetComponent<MeshRenderer>().material = redLight;
                trafficLightGreen.GetComponent<MeshRenderer>().material = noLight;
                break;
            case 1: // green
                trafficLightRed.GetComponent<MeshRenderer>().material = noLight;
                trafficLightGreen.GetComponent<MeshRenderer>().material = greenLight;
                break;
        }
    }


    void ChangePedSignalLight()
    {
        pedNum = (pedNum + 1) % 2;
        switch (pedNum)
        {
            case 0:
                pedLightRed.GetComponent<MeshRenderer>().material = redLight;
                pedLightGreen.GetComponent<MeshRenderer>().material = noLight;
                break;
            case 1:
                pedLightRed.GetComponent<MeshRenderer>().material = noLight;
                pedLightGreen.GetComponent<MeshRenderer>().material = greenLight;
                break;
        }
    }
}
