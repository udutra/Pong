using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D ballRb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (ballRb.velocity.x > 0.0f) {
            if (ballRb.position.y > this.transform.position.y) {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ballRb.position.y < this.transform.position.y) {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else {
            if (this.transform.position.y > 0.0f) {
                rb.AddForce(Vector2.down * speed);
            }
            else if (this.transform.position.y <0.0f) {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }

}
