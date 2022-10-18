using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 siguientePosicion;
    public float velocidad = 2;
    byte numeroSiguientePosicion = 0;
    float distanciaCambio = 0.2f;

    void Start()
    {
        siguientePosicion = wayPoints[0].position;

        if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            FindObjectOfType<Enemigo>().SendMessage("IncrementarVelocidad");

        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            siguientePosicion, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= wayPoints.Length)
            {
                numeroSiguientePosicion = 0;
            }
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("PerderVida");
    }

    public void IncrementarVelocidad()
    {
        velocidad += 0.5f;
    }
}
