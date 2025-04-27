using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D PlayerBody;

    private void Awake()
    {
        PlayerBody = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Movimiento del jugador
        PlayerBody.velocity = new Vector2(horizontalInput* speed, PlayerBody.velocity.y);
        //Cambiar la gravedad
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.gravityScale = -PlayerBody.gravityScale;
        }
        //Cambiar el sprite de acuerdo a la dirección de vertical y horizontal 4 casos posibles

        if (horizontalInput > 0.1f && PlayerBody.gravityScale < 0.1f)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else if (horizontalInput < -0.1f && PlayerBody.gravityScale < 0.1f)
        {
            transform.localScale = new Vector3(-1f, -1f, 1f);
        }
        else if (horizontalInput > 0.1f && PlayerBody.gravityScale > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < -0.1f && PlayerBody.gravityScale > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
