using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndioFinal : MonoBehaviour
{
    public GameObject cipo, jaula, plataforma1, plataforma2;
    public ControllerFase4 controller;

    private void Start()
    {
        cipo.SetActive(false);
        plataforma1.SetActive(false);
        plataforma2.SetActive(false);
    }

    public void AtivaCipo()
    {
        cipo.SetActive(true);
    }


    public void DestroiCipo()
    {
        Destroy(cipo);
        Destroy(jaula);
        plataforma1.SetActive(true);
        plataforma2.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.TerminaFase4();
        }
    }
}
