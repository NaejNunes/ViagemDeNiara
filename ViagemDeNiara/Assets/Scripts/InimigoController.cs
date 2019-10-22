using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{    
    public float velocidade;

    private bool movimentacaoDireita;

    public bool tigre;

    void Start()
    {
        movimentacaoDireita = true;
    }

    void Update()
    {
        if (tigre == true)
        {
            if (movimentacaoDireita == true)
            {
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
                GetComponent<SpriteRenderer>().flipX = true;
            }

            else
            {
                transform.Translate(Vector2.left * velocidade * Time.deltaTime);
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            if (movimentacaoDireita == true)
            {
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
                GetComponent<SpriteRenderer>().flipX = false;
            }

            else
            {
                transform.Translate(Vector2.left * velocidade * Time.deltaTime);
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TagLimiteDireita"))
        {
            Debug.Log("TocouDireita");
            movimentacaoDireita = false;

        }

        if (collision.gameObject.CompareTag("TagLimiteEsquerda"))
        {
            Debug.Log("TocouEsqueda");
            movimentacaoDireita = true;
        }
    }
}
