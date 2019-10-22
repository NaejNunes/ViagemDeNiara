using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase3Controller : MonoBehaviour
{
    public GameObject painelInicio, painelFim;
    public PlataformaMover plataforma1, plataforma2;

    private void Start()
    {
        painelFim.SetActive(false);
        painelInicio.SetActive(true);
        Time.timeScale = 0;
        plataforma1.Pausa();
        plataforma2.Pausa();
    }

    public void ComecaFase()
    {
        painelInicio.SetActive(false);
        Time.timeScale = 1;
        plataforma1.Move();
        plataforma2.Move();
    }

    public void TerminaFase3()
    {
        painelFim.SetActive(true);
        Time.timeScale = 0;
    }

    public void CarregaFase4()
    {
        SceneManager.LoadScene("Fase4");
    }
}
