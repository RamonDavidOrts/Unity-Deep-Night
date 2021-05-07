using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoVidas = null;
    [SerializeField] TextMeshProUGUI textoPuntos = null;
    [SerializeField] TextMeshProUGUI textoGameOver = null;
    [SerializeField] Image iconoLlave = null;
    [SerializeField] AudioClip sonidoMuerte = null;
    [SerializeField] AudioClip sonidoPuerta = null;
    GameStatus gameStatus;
    

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        textoGameOver.enabled = false;
        iconoLlave.enabled = false;
        textoPuntos.text = gameStatus.GetPuntos().ToString();
        textoVidas.text = gameStatus.GetVidas().ToString();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void AnotarItemRecogido()
    {
        gameStatus.SumaPuntos(10);
        textoPuntos.text = gameStatus.GetPuntos().ToString();
    }

    public void AnotarLlaveRecogida()
    {
        iconoLlave.enabled = true;
    }

    public void AbrirPuerta()
    {
        if (iconoLlave.enabled)
            AudioSource.PlayClipAtPoint(sonidoPuerta, 
                Camera.main.transform.position);
        AvanzarNivel();
    }

    public void AvanzarNivel()
    {
        if (gameStatus.GetNivelActual() < gameStatus.GetNivelMasAlto())
            gameStatus.SetNivelActual(gameStatus.GetNivelActual() + 1);
        else
            gameStatus.SetNivelActual(1);

        SceneManager.LoadScene("Nivel" + gameStatus.GetNivelActual());
    }

    public void PerderVida()
    {
        AudioSource.PlayClipAtPoint(sonidoMuerte, Camera.main.transform.position);
        gameStatus.RestaVida();
        textoVidas.text = gameStatus.GetVidas().ToString();

        FindObjectOfType<Jugador>().SendMessage("Recolocar");
        if (gameStatus.GetVidas() <= 0)
        {
            StartCoroutine(TerminarPartida());
        }
    }

    private IEnumerator TerminarPartida()
    {
        textoGameOver.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
