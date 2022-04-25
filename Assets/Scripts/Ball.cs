using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D ballRb;
    [SerializeField] private float initialSpeed = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;

    private void Start() {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch() {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;

        ballRb.velocity = new Vector3(xVelocity, yVelocity) * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Paddle")) {
            ballRb.velocity *= velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Goal1")) {
            GameManager.Instance.Paddle2Scored();
            Goal();
        }
        else {
            GameManager.Instance.Paddle1Scored();
            Goal();
        }
    }

    private void Goal() {
        GameManager.Instance.Restart();
        Launch();
    }
}
