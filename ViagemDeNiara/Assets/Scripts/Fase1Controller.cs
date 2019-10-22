using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase1Controller : MonoBehaviour
{
    public GameObject painelInicio, painelFim;
    public PlataformaMover plataformaMovendo;

    private void Start()
    {
        painelFim.SetActive(false);
        painelInicio.SetActive(true);
        Time.timeScale = 0;
        plataformaMovendo.Pausa();
    }

    public void ComecaFase()
    {
        painelInicio.SetActive(false);
        Time.timeScale = 1;
        plataformaMovendo.Move();
    }

    public void TerminaFase1()
    {
        painelFim.SetActive(true);
        Time.timeScale = 0;
    }

    public void CarregaFase2()
    {
        SceneManager.LoadScene("Fase2");
    }
}
