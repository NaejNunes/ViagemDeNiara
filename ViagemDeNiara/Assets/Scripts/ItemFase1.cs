using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFase1 : MonoBehaviour
{
    public GameObject infoItem;
    public GameObject player;
    public bool itemCipo, itemOvo, itemColar;

    private void Start()
    {
        infoItem.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            infoItem.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infoItem.SetActive(false);
    }
}
