using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject pangolinPc;
    public float yOffset = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pangolinPc.transform.position.x, pangolinPc.transform.position.y + yOffset, -10);
    }
}
