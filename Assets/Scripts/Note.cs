﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool isAvailable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -speed);
        isAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAvailable(bool b)
    {
        isAvailable = b;
    }
}
