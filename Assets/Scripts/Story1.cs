using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story1 : MonoBehaviour
{
    [SerializeField] private GameObject playerStanding;
    [SerializeField] private GameObject playerBeating;
    [SerializeField] private GameObject playerLying;

    [SerializeField] private GameObject enemyParent;
    [SerializeField] private Transform enemyParentStart;
    [SerializeField] private Transform enemyParentEnd;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] enemyEndPos;

    [SerializeField] private GameObject enemyBanner1;
    [SerializeField] private GameObject enemyBanner2;
    [SerializeField] private GameObject playerBanner;
    [SerializeField] private GameObject playerBanner2;

    [SerializeField] private Image blackoutSprite;

    private void Start()
    {
        StartCoroutine(StartSequnce());
    }

    private IEnumerator StartSequnce()
    {
        iTween.MoveTo(enemyParent, iTween.Hash("position", enemyParentEnd.position, "time", 2, "easetype", iTween.EaseType.linear));

        yield return new WaitForSeconds(2);

        enemyBanner1.SetActive(true);

        yield return new WaitForSeconds(2);

        enemyBanner1.SetActive(false);

        for (int i = 0; i < enemies.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, 1));

            iTween.MoveTo(enemies[i], iTween.Hash("name", "ene" + i.ToString(), "position", playerStanding.transform.position,//enemyEndPos[i].position,
                "time", 0.5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
        }

        playerStanding.SetActive(false);
        playerBeating.SetActive(true);

        yield return new WaitForSeconds(5);

        for (int i = 0;i < enemies.Length; i++)
        {
            iTween.StopByName("ene" + i.ToString());
        }

        playerBeating.SetActive(false);
        playerLying.SetActive(true);

        enemyBanner2.SetActive(true);
        iTween.MoveTo(enemyParent, iTween.Hash("position", enemyParentStart.position, "time", 2, "easetype", iTween.EaseType.linear));


        yield return new WaitForSeconds(2);

        playerBanner.SetActive(true);

        yield return new WaitForSeconds(2);

        playerBanner.SetActive(false);
        playerBanner2.SetActive(true);

        yield return new WaitForSeconds(2);

        iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", 2, "easetype", iTween.EaseType.linear,
            "onupdatetarget", gameObject, "onupdate", "UpdateBlackoutColor"));

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Level 1");
    }

    private void UpdateBlackoutColor(float f)
    {
        Color c = blackoutSprite.color;
        c.a = f;
        blackoutSprite.color = c;
    }
}
