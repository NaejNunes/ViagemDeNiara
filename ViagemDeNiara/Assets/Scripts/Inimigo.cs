using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject Player;
    float timer, velX = 0.05f;
    
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            velX = velX * -1;
            timer = 0;
        }

        transform.Translate(Vector3.right * velX);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
        {
            Destroy(Player);
        }
    }
}
