using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private int hitsToKill;
    private int hits;
    private bool dead;

    private TentacionEvent parent;
    
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.GetComponentInParent<TentacionEvent>();
        parent.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseUpAsButton()
    {
        hits++;

        if (hits > hitsToKill)
        {
            transform.position = new Vector3(0, -10, 0);
            
            if(!dead)
                parent.CompleteTent();
        }
    }
}
