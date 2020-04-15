using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // 物理演算が実行される直前に呼び出されるメソッド。物理演算に関するコードをこのメソッドに記述する。
    private void FixedUpdate() {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
    }
}