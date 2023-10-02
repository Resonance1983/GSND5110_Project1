using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelName;

    void Start()
    {
        StartCoroutine(DisplayLevelName());
    }

    private IEnumerator DisplayLevelName()
    {
        levelName.SetActive(true);
        yield return new WaitForSeconds(3);
        levelName.SetActive(false);
    }
}
