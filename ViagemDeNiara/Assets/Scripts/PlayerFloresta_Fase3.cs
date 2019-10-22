using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFloresta_Fase3 : MonoBehaviour
{
    public KeyCode cima;
    public KeyCode esquerda;
    public KeyCode direita;
    public KeyCode pegaItem;
    public float forcaPulo;
    bool colidindo1 = false, colidindo2 = false, colidindo3 = false, colidindoOvo = false, checarChao = true;
    private SpriteRenderer spriteRenderer;
    private Animator animacao;
    public Fase3Controller controllerFase3;
    Transform playerTransform;
    Rigidbody2D corpoPlayer;
    float timer = 0f;
    public GameObject Cipo1, Cipo2, Cipo3, ovo;
    public IndioFase3 indiopreso;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
        playerTransform = transform;

        corpoPlayer = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //INICIA E PARA AS ANIMAÇÕES
        if (Input.GetKey(esquerda) || Input.GetKey(direita))
        {
            animacao.SetFloat("Andando", 1);
        }
        else
        {
            animacao.SetFloat("Andando", 0);
        }
        if (Input.GetKey(cima))
        {
            animacao.SetFloat("Pulando", 1);
        }
        else
        {
            animacao.SetFloat("Pulando", 0);
        }
        if (Input.GetKey(esquerda) || Input.GetKey(direita) && Input.GetKey(cima))
        {
            animacao.SetFloat("PuloAndando", 1);
        }
        else
        {
            animacao.SetFloat("PuloAndando", 0);
        }

        if (Input.GetKey(cima) && checarChao == true)
        {
            corpoPlayer.AddForce(new Vector2(0, forcaPulo));
            checarChao = false;

        }

        if (checarChao == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1.7f)
            {
                checarChao = true;
                timer = 0;
            }
        }

        if (Input.GetKey(esquerda))
        {
            transform.Translate(Vector3.left * 0.10f);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(direita))
        {
            transform.Translate(Vector3.right * 0.10f);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(pegaItem) && colidindo1)
        {
            indiopreso.DestroiCipo1();
            Destroy(Cipo1);
        }
        if (Input.GetKey(pegaItem) && colidindo2)
        {
            indiopreso.DestroiCipo2();
            Destroy(Cipo2);
        }
        if (Input.GetKey(pegaItem) && colidindo3)
        {
            indiopreso.DestroiCipo3();
            Destroy(Cipo3);
        }

        if (Input.GetKey(pegaItem) && colidindoOvo)
        {
            Destroy(ovo);
            indiopreso.PegaOvo();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //MORRE AO TOCAR NO INIMIGO
        if (collision.gameObject.CompareTag("TagInimigo"))
        {
            SceneManager.LoadScene("Fase3");
        }

        if (collision.gameObject == Cipo1)
        {     
              colidindo1 = true;
        }

        if (collision.gameObject == Cipo2)
        {
            colidindo2 = true;
        }

        if (collision.gameObject == Cipo3)
        {
            colidindo3 = true;
        }

        if (collision.gameObject == ovo)
        {
            colidindoOvo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colidindo1 = false;
        colidindo2 = false;
        colidindo3 = false;
        colidindoOvo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlataformaMovendo")
        {
            playerTransform.parent = collision.transform;
        }

        /*if (collision.gameObject.CompareTag("TagChao") || collision.gameObject.CompareTag("TagAndaime") || collision.gameObject.CompareTag("PlataformaMovendo"))
        {
            checarChao = true;
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlataformaMovendo")
        {
            playerTransform.parent = null;
        }
    }
}


