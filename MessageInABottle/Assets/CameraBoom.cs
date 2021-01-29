using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    private Vector3 boom;
    // Start is called before the first frame update
    void Start()
    {
        boom = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = boom;
    }
}
