using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacique : MonoBehaviour
{
    public float timer = 0f, timerTiro = 0f, vel = 0.10f, posX, posY;
    public GameObject limiteEsquerda, limiteDireita, tiroEsquerda, tiroDireita;
    bool parado = false, esquerda = false, direita = false, pausado=true;
    public IndioFinal indio;
    SpriteRenderer renderer;
    Animator animacao;
    int vida = 3;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }

    void Update()
    {
        if(vida <= 0)
        {
            indio.AtivaCipo();
            Destroy(this.gameObject);
        }


        posX = transform.position.x;
        posY = transform.position.y;

        if (!pausado)
        {
            if (parado == false)
            {
                transform.Translate(Vector3.right * vel);
            }
        }
        
        


        if (parado)
        {
            timer += Time.deltaTime;
            timerTiro += Time.deltaTime;
            animacao.SetFloat("Andando", 0);

            if (timerTiro > 2 && parado)
            {
                if (esquerda)
                {
                    Instantiate(this.tiroEsquerda, new Vector2(this.posX + 0.5f, this.posY + 0.7f), Quaternion.identity);
                }
                else if (direita)
                {
                    Instantiate(this.tiroDireita, new Vector2(this.posX + 0.5f, this.posY + 0.7f), Quaternion.identity);
                }
                timerTiro = 0;
            }
            if (timer >= 10)
            {
                parado = false;
                timer = 0;
            }
        }
        else
        {
            animacao.SetFloat("Andando", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == limiteEsquerda)
        {
            vel = vel * -1;
            parado = true;
            esquerda = true;
            direita = false;
            renderer.flipX = false;
        }
        if (collision.gameObject == limiteDireita)
        {
            vel = vel * -1;
            parado = true;
            esquerda = false;
            direita = true;
            renderer.flipX = true;
        }
    }

    public void TiraVida()
    {
        vida--;
    }

    public void Retoma()
    {
        pausado = false;
    }

}


