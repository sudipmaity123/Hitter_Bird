using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField]
    private Sprite deathSprite;

    [SerializeField]
    private ParticleSystem particlesystem;


    private bool died;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
       {
            StartCoroutine(Die());
       }
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if (died)
        {
            return false;
        }

        RedPlayer player = collision.gameObject.GetComponent<RedPlayer>();
        if(player != null || collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }
        return false;
    }

    IEnumerator Die()
    {
        died = true;

        particlesystem.Play();
        GetComponent<SpriteRenderer>().sprite = deathSprite;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
