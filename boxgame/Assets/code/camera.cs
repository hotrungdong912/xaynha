using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector3 targetpos;

    private float smoothMove = 1f;

     void Start()
    {
        targetpos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, smoothMove * Time.deltaTime);
    }
}
