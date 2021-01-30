using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    public static EventManager Instance()
    {
        if (instance) return instance;
        return instance = new EventManager();
    }
    
    public Transform EventSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
