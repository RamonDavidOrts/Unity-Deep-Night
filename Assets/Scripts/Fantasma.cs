using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints = null;
    float velocidad = 0.05f;
    float distanciaCambio = 0.1f;
    byte siguientePosicion = 0;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            wayPoints[siguientePosicion].transform.position,
            velocidad);

        if (Vector3.Distance(transform.position,
            wayPoints[siguientePosicion].transform.position) < distanciaCambio)
        {
            siguientePosicion++;
            if (siguientePosicion >= wayPoints.Count)
                siguientePosicion = 0;

            if (siguientePosicion == 0 || siguientePosicion == 1)
                Gira();
        }
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        FindObjectOfType<GameController>().SendMessage("PerderVida");
    }

    private void Gira()
    {
        anim.Play("FantasmaGirando");
        transform.localScale = new Vector3(
            transform.localScale.x * -1f,
            transform.localScale.y,
            transform.localScale.z);
    }
}
