using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] AudioClip sonido = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        FindObjectOfType<GameController>().SendMessage("AnotarItemRecogido");
        AudioSource.PlayClipAtPoint(sonido, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
