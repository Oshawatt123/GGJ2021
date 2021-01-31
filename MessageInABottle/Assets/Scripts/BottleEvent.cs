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

    public List<string> narratives;

    private NarrativeManager nm;

    [SerializeField] private bool firstTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        nm = GameObject.FindWithTag("Player").GetComponent<NarrativeManager>();
        
        if(firstTimer) nm.StartNarrative(narratives);
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
        // start the narrative manager
        nm.StartNarrative(narratives);
        
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
