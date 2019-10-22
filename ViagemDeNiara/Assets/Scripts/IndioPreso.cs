using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndioPreso : MonoBehaviour
{
    public GameObject Cipo, Jaula, player, mensagemFome, mensagemPreso;
    public Fase2Controller controller;
    bool fome = true, preso = true;

    public void DestroiCipo()
    {
        Destroy(Cipo);
        Destroy(Jaula);
        preso = false;
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

            if (preso)
            {
                mensagemPreso.SetActive(true);
            }

            if (!preso && !fome)
            {
                controller.TerminaFase2();
            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mensagemFome.SetActive(false);
        mensagemPreso.SetActive(false);
    }
}
