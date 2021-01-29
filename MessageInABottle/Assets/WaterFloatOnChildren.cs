using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class WaterFloatOnChildren : MonoBehaviour
{
    [SerializeField] private List<Transform> children;
    [SerializeField] private float offsetY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ((children[0].position.y + children[1].position.y) / 2) + offsetY, transform.position.z);
        transform.rotation = Quaternion.Euler(GetX(), 0, GetZ());
    }

    private float GetZ()
    {
        float yDistance = children[1].position.y - children[0].position.y;
        float xDistance = children[1].position.x - children[0].position.x;

        float Z = Mathf.Atan2(yDistance , xDistance) * 15;
        Debug.Log(yDistance + "/" + xDistance + "=" + Z);

        return Z;
    }
    
    private float GetX()
    {
        float yDistance = children[1].position.y - children[0].position.y;
        float zDistance = children[1].position.z - children[0].position.z;

        float X = Mathf.Atan2(yDistance , zDistance) * -15;
        Debug.Log(yDistance + "/" + zDistance + "=" + X);

        return X;
    }
}
