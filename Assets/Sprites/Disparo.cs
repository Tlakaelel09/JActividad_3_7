using UnityEngine;

public class Disparo : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    public GameObject prefabBala;
    public Transform puntoDisparo;
    public float velocidadBala = 15f;
    public float tiempoEntreDisparos = 0.25f; // Cadencia uniforme para que no se encimen

    private float tiempoSiguienteDisparo = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Z) && Time.time >= tiempoSiguienteDisparo)
        {
            DispararBala();
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void DispararBala()
    {

        if (animator != null)
        {
            animator.SetTrigger("Disparar");
        }


        GameObject balaNueva = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = balaNueva.GetComponent<Rigidbody2D>();


        rbBala.gravityScale = 0f;
        float direccion = transform.localScale.x > 0 ? 1f : -1f;
        rbBala.linearVelocity = new Vector2(velocidadBala * direccion, 0f);
        balaNueva.transform.localScale = new Vector3(direccion, 1, 1);


        Destroy(balaNueva, 2f);
    }
}