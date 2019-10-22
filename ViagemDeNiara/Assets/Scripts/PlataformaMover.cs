using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMover : MonoBehaviour
{
    public GameObject limiteEsquerda, limiteDireita;
    float vel = 0.08f;
    bool pausado = true;

    void Update()
    {
        if (pausado == false)
        {
            transform.Translate(Vector3.left * vel);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == limiteDireita || collision.gameObject == limiteEsquerda)
        {
            vel = vel * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == limiteDireita || collision.gameObject == limiteEsquerda)
        {
            vel = vel * -1;
        }
    }

    public void Pausa()
    {
        pausado = true;
    }

    public void Move()
    {
        pausado = false;
    }
}
