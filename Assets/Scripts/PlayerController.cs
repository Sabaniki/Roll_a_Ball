using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;

    private Rigidbody rb;
    private int count;

    private void UpdateCountText() => countText.text = "Count: " + count.ToString();

    private void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateCountText();
    }

    // 物理演算が実行される直前に呼び出されるメソッド。物理演算に関するコードをこのメソッドに記述する。
    private void FixedUpdate() {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("PickUp")) return;
        other.gameObject.SetActive(false);
        count++;
        UpdateCountText();
    }
}