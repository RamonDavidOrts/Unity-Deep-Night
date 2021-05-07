using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private int puntos = 0;
    private int vidas = 3;
    private int nivelActual = 1;
    private int nivelMasAlto = 2;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPuntos()
    {
        return puntos;
    }

    public void SumaPuntos(int Maspuntos)
    {
        puntos += Maspuntos;
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void RestaVida()
    {
        vidas--;
    }

    public int GetNivelActual()
    {
        return nivelActual;
    }

    public void SetNivelActual(int nivel)
    {
        nivelActual = nivel;
    }

    public int GetNivelMasAlto()
    {
        return nivelMasAlto;
    }

    public void Reinicia()
    {
        vidas = 3;
        puntos = 0;
        nivelActual = 1;
    }
}