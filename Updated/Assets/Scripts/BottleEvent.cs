﻿using System;
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
        
    }

    private void OnCollisionEnter(Collision other)
    {
        throw new NotImplementedException();
    }

    public void StartEvent()
    {
        transform.position = EventManager.Instance().EventSpawnPoint.position;
    }
}
