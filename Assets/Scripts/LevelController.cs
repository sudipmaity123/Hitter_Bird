using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Monster[] _monster;

    [SerializeField]
    private string nextLevelName;

    void OnEnable()
    {
        _monster = FindObjectsOfType<Monster>();
    }
    // Update is called once per frame
    void Update()
    {
        if(monstersAreAlldEATH())
        {
            goToNextlEVEL();
        }
    }

    void goToNextlEVEL()
    {
        Debug.Log("Go To " + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }

    bool monstersAreAlldEATH()
    {
        foreach(var monster in _monster)
        {
            if(monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
