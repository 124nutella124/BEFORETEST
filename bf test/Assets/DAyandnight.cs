using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAyandnight : MonoBehaviour
{
    public float speed = 1.0f;
    void Update()
    {
        transform.Rotate(new Vector3(speed, 0f, 0f));
    }
}