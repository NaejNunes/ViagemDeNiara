using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerFase4 : MonoBehaviour
{
    public GameObject painelInicio, painelFim;
    public Cacique cacique;

    private void Start()
    {
        painelFim.SetActive(false);
        painelInicio.SetActive(true);
        Time.timeScale = 0;

    }

    public void ComecaFase()
    {
        painelInicio.SetActive(false);
        Time.timeScale = 1;
        cacique.Retoma();
    }

    public void TerminaFase4()
    {
        painelFim.SetActive(true);
        Time.timeScale = 0;
    }

    public void CarregaFinal()
    {
        SceneManager.LoadScene("FimDeJogo");
    }
}
