using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story2 : MonoBehaviour
{
    [SerializeField] private GameObject enemyParent;
    [SerializeField] private Transform enemyParentEnd;
    [SerializeField] private GameObject enemyBanner;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBanner;
    [SerializeField] private GameObject playerBanner2;

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject flowerPS;

    [SerializeField] private GameObject heartSprite;
    [SerializeField] private GameObject heartText;

    [SerializeField] private GameObject endMenu;

    private void Start()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        iTween.MoveTo(enemyParent, iTween.Hash("position", enemyParentEnd.position, "time", 2, "easetype", iTween.EaseType.linear));

        yield return new WaitForSeconds(2);

        playerBanner.SetActive(true);
        gun.SetActive(true);

        yield return new WaitForSeconds(2);

        enemyBanner.SetActive(true);

        yield return new WaitForSeconds(2);

        enemyBanner.SetActive(false);
        playerBanner.SetActive(false);
        playerBanner2.SetActive(true);
        flowerPS.SetActive(true);

        yield return new WaitForSeconds(3);

        gun.SetActive(false);
        player.SetActive(false);
        playerBanner2.SetActive(false);
        flowerPS.SetActive(false);
        enemyParent.SetActive(false);
        heartSprite.SetActive(true);

        yield return new WaitForSeconds(2);

        heartText.SetActive(false);
        iTween.ScaleTo(heartSprite, new Vector3(30, 30, 30), 2);

        yield return new WaitForSeconds(1);

        endMenu.SetActive(true);

    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level 0");
    }
}
