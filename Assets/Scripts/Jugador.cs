using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    float xInicial, yInicial;
    float velocidad = 5f;
    float fuerzaSalto = 70f;
    float alturaPersonaje;
    Animator anim;
    bool mirandoDerecha = true;
    Rigidbody2D rigidbody;
    [SerializeField] AudioClip sonidoSalto = null;
    AudioSource audioSource;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D impacto = Physics2D.Raycast(
                transform.position,
                new Vector2(0, -1));
            if (impacto.collider != null)
            {
                float distanciaAlSuelo = impacto.distance;
                bool tocandoElSuelo = distanciaAlSuelo < alturaPersonaje;
                if (tocandoElSuelo)
                {
                    audioSource.clip = sonidoSalto;
                    audioSource.Play();
                    anim.Play("JugadorSaltando");
                    GetComponent<Rigidbody2D>().AddForce(
                        Vector2.up * fuerzaSalto, 
                        ForceMode2D.Impulse);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0f && mirandoDerecha)
            Gira();
        else if (horizontal > 0f && !mirandoDerecha)
            Gira();

        if (horizontal > 0.1f || horizontal < -0.1f)
            anim.Play("JugadorCorriendo");

        //transform.Translate(horizontal * velocidad, 0, 0);
        rigidbody.velocity = new Vector2(
            horizontal * velocidad,
            rigidbody.velocity.y);
    }

    private void Gira()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.localScale = new Vector3(
            transform.localScale.x * -1f,
            transform.localScale.y,
            transform.localScale.z); 
    }

    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
