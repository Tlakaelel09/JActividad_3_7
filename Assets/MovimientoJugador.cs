using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool enElSuelo = true;
    private float movimientoX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Leer controles (Flechas izquierda/derecha o teclas A/D)
        movimientoX = Input.GetAxisRaw("Horizontal");

        if (movimientoX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoX < 0) transform.localScale = new Vector3(-1, 1, 1);

        animator.SetBool("Caminando", movimientoX != 0);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && enElSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enElSuelo = false;
        }
    }

    void FixedUpdate()
    {
         rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }
}