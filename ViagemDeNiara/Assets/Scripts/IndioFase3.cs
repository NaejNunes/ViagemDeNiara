using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndioFase3 : MonoBehaviour
{
    public GameObject Jaula, player, mensagemFome, mensagemPreso;
    public Fase3Controller controller;
    bool fome = true, preso = true, cipo1=false, cipo2 = false, cipo3 = false;
    int contador=0;

    public void DestroiCipo1()
    {
        cipo1 = true;
    }

    public void DestroiCipo2()
    {
        cipo2 = true;
    }

    public void DestroiCipo3()
    {
        cipo3 = true;
    }

    public void PegaOvo()
    {
        fome = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (fome)
            {
                mensagemFome.SetActive(true);
            }

            if (!cipo1 || !cipo2 || !cipo3)
            {
                mensagemPreso.SetActive(true);
            }

            if (cipo1 && cipo2 && cipo3 && !fome)
            {
                controller.TerminaFase3();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mensagemFome.SetActive(false);
        mensagemPreso.SetActive(false);
    }

    private void Update()
    {
        if (cipo1 && cipo2 && cipo3)
        {
            Destroy(Jaula);
        }
    }
}
