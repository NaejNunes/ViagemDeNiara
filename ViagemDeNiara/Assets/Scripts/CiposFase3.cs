using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiposFase3 : MonoBehaviour
{
    public GameObject player, tecla;
    void Start()
    {
        tecla.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            tecla.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tecla.SetActive(false);
    }
}
