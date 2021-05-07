using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpiente : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints = null;
    float velocidad = 0.02f;
    float distanciaCambio = 0.1f;
    byte siguientePosicion = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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

            Gira();
        }
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        FindObjectOfType<GameController>().SendMessage("PerderVida");
    }

    private void Gira()
    {
        transform.localScale = new Vector3(
            transform.localScale.x * -1f,
            transform.localScale.y,
            transform.localScale.z);
    }
}
