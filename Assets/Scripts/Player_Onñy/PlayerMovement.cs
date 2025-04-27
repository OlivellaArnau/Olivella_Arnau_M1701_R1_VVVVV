using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7.5f;
    [SerializeField]private float rayCastDistance = 1.5f;
    private bool grounded;
    private Rigidbody2D PlayerBody;
    private Animator anim;

    // Variables para retrasar la rotaci�n
    public int rotationDelayFrames = 24; // N�mero de fotogramas de retardo
    private int currentFrameCount;
    private bool gravitySwitchRequested;

    private void Awake()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Movimiento del jugador
        PlayerBody.velocity = new Vector2(horizontalInput * speed, PlayerBody.velocity.y);

        // Solicitar cambio de gravedad con retardo
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            gravitySwitchRequested = true;
            currentFrameCount = 0; // Reiniciar contador de fotogramas
            PlayerBody.gravityScale = -PlayerBody.gravityScale;
            anim.SetBool("Jumping", true); // Activamos la animaci�n de salto
        }

        // Aplicar el cambio de gravedad y rotaci�n despu�s del retardo
        if (gravitySwitchRequested)
        {
            currentFrameCount++; // Incrementar contador de fotogramas
            if (currentFrameCount >= rotationDelayFrames)
            {
                // Cambiar la gravedad y aplicar la rotaci�n despu�s del n�mero especificado de fotogramas

                transform.Rotate(-180f, 0f, 0f);
                gravitySwitchRequested = false; // Reiniciar solicitud de cambio de gravedad
                anim.SetBool("Jumping", false); // Desactivar animaci�n de salto al tocar el suelo
            }
        }

        // Control de la direcci�n de la escala del jugador
        if (horizontalInput > 0.1f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, 1f);
        }
        else if (horizontalInput < -0.1f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, 1f);
        }

        // Detectar si el jugador est� en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayCastDistance);
        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            grounded = true;
            
        }
        else
        {
            grounded = false;
        }

        // Control de animaciones
        anim.SetBool("Running", horizontalInput != 0 && grounded);
    }
}
