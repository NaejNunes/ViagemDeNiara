using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject painelInformacoes;
    public GameObject painelControles;

   public void FechaPaineis()
    {
        painelControles.SetActive(false);
        painelInformacoes.SetActive(false);
    }

    public void AbrePainelInformacoes()
    {
        painelInformacoes.SetActive(true);
    }

    public void AbrePainelControles()
    {
        painelControles.SetActive(true);
    }

    public void CarregaFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void FechaJogo()
    {
        Application.Quit();
    }
}
