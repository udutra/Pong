using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private float yBound = 3.75f;

    [SerializeField] private float speed = 7;
    [SerializeField] private bool ispaddle1, isComputerPaddle;

    private void Update() {

        if (isComputerPaddle) {
            return;
        }

        float movement;

        if (ispaddle1) {
            movement = Input.GetAxisRaw("Vertical");
        }
        else{
            movement = Input.GetAxisRaw("Vertical2");
        }

        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);

        transform.position = paddlePosition;
    }

}
