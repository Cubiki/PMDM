using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    [SerializeField] float velocidadAvance = 600f;
    float velocidadRotacion = 200f;
    float xInicial, zInicial;
    private int vidas = 3;
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoGameOver;
    public TextMeshProUGUI textoFin;
    float inicio = 0;
    float final = 5;

    void Start()
    {
        xInicial = transform.position.x;
        zInicial = transform.position.z;
    }

    void Update()
    {
        textoContador.text = SceneManager.GetActiveScene().name + 
            "    Vidas: " + vidas.ToString();

        float avance = Input.GetAxis("Vertical") * velocidadAvance * 
            Time.deltaTime;
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion * 
            Time.deltaTime;

        transform.Rotate(Vector3.up, rotacion);
        transform.position += avance * Time.deltaTime * transform.forward;


        if (transform.position.y <= -1 && 
            SceneManager.GetActiveScene().name == "Nivel1")
        {
            SceneManager.LoadScene("Nivel2");

        }
        else if(transform.position.y <= -1 &&
            SceneManager.GetActiveScene().name == "Nivel2")
        {
            textoFin.gameObject.SetActive(true);
            Pausar();

            Debug.Log("Partida terminada");
        }


        if (vidas <= 0)
        {
            textoGameOver.gameObject.SetActive(true);
            Pausar();

            Debug.Log("Partida terminada");
        }
    }

    public void PerderVida()
    {
        Debug.Log("Una vida menos");
        transform.position = new Vector3(xInicial, transform.position.y,
            zInicial);
        vidas--;
    }

    public void Pausar()
    {
        inicio += Time.deltaTime;

        if (inicio >= final)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
