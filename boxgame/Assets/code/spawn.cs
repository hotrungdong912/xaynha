using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject box;

    public void SpawnBox()
    {
        GameObject box_prefab = Instantiate(box);

        Vector3 temp = transform.position;
        temp.z = 0;

        box_prefab.transform.position = transform.position;
    }
}
