using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeadBackground : MonoBehaviour
{
    private Vector3 StartPos;
    private float repeadWidth;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        repeadWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < StartPos.x - repeadWidth)
        {
            transform.position = StartPos;
        }
        
    }
}
