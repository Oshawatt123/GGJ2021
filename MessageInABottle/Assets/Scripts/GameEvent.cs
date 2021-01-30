using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    [HideInInspector] public BottleEvent trigger;
    
    [SerializeField] private Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void SpawnEvent(BottleEvent eventTrigger)
    {
        Debug.Log("Event " + transform.name + " spawned");
        trigger = eventTrigger;
        transform.position = spawnPoint.position;
    }

    public void FollowSpawn()
    {
        transform.position = spawnPoint.position;
    }
}
