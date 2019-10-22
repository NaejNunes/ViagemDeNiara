using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public KeyCode cima;
    public KeyCode esquerda;
    public KeyCode direita;
    public KeyCode pegaItem;
    public GameObject item, Cacique, caciqueMiragem;
    public float forcaPulo;
    bool colidindo = false, checarChao = true;
    private SpriteRenderer spriteRenderer;
    private Animator animacao;
    public Fase1Controller controllerFase1;
    Transform playerTransform;
    public Rigidbody2D corpoPlayer;
    float timer = 0f;
    

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
        playerTransform = transform;
        // Cacique.SetActive(false);

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


        if (Input.GetKey(pegaItem) && colidindo == true)
        {
            Destroy(item);
            //controllerFase1.TerminaFase1();
            Cacique.SetActive(true);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == item)
        {
            colidindo = true;
        }

        if (collision.gameObject == Cacique)
        {
            controllerFase1.TerminaFase1();
        }

        //AO TOCAR NO GATILHO O CACIQUE APARECE
        if (collision.gameObject.CompareTag("TagGatilhoCacique"))
        {
            caciqueMiragem.SetActive(true);
        }

        //MORRE AO TOCAR NO INIMIGO
        if (collision.gameObject.CompareTag("TagInimigo"))
        {
            SceneManager.LoadScene("Fase1");
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;

        if (collision.gameObject.CompareTag("TagGatilhoCacique"))
        {
            caciqueMiragem.SetActive(false);
        }
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
