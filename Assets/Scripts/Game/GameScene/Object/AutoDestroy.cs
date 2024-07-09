using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time=2;

    private void Start()
    {
        Destroy(gameObject,time);
    }
}
