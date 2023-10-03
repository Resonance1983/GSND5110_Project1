using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject revengeBanner;

    [SerializeField] private bool isCollectible = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController p = collision.GetComponent<PlayerController>();

        if (p != null )
        {
            if (isCollectible)
            {
                revengeBanner.SetActive(true);

                gameObject.GetComponent<SpriteRenderer>().enabled = false;

                StartCoroutine(LoadScene());
            }
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Level 3");
    }
}
