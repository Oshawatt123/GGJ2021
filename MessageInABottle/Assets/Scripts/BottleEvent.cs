using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottleEvent : MonoBehaviour
{
    public UnityEvent startEvents;

    public UnityEvent passEvent;
    public UnityEvent failEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1*Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        startEvents.Invoke();
    }

    public void Spawn()
    {
        try
        {
            transform.position = EventManager.Instance().EventSpawnPoint.position;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debug.LogError("Object " + gameObject.name + " failed to get event manager instance");
            throw;
        }
        
    }

    public void Pass()
    {
        passEvent.Invoke();
    }

    public void Fail()
    {
        failEvent.Invoke();
    }
}
