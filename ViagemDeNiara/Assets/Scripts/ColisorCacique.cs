using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorCacique : MonoBehaviour
{
    float timer = 12;
    public Cacique cacique;
    bool colidindo = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (timer <= 0f && colidindo)
        {
            cacique.TiraVida();
            timer = 12;
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colidindo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;
    }
}
