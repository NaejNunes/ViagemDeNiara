/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase2Controller : MonoBehaviour
{
    public PlataformaMover PlataformaMover;

    void Start()
    {
        PlataformaMover.Move();
    }

    void Update()
    {
        
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase2Controller : MonoBehaviour
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

    public void TerminaFase2()
    {
        painelFim.SetActive(true);
        Time.timeScale = 0;
    }

    public void CarregaFase3()
    {
        SceneManager.LoadScene("Fase3");
    }
}
