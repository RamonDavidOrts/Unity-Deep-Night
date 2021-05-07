using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] AudioClip sonidoPlay = null;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameStatus>().Reinicia();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzarJuego()
    {
        AudioSource.PlayClipAtPoint(sonidoPlay, Camera.main.transform.position);
        SceneManager.LoadScene("Nivel1");
    }
}
