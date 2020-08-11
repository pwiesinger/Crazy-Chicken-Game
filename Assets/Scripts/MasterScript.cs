using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterScript : MonoBehaviour
{
    public Canvas canvas;
    public Canvas inGameOverlay;
    public Text coinCount;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        inGameOverlay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Dead();
        }
    }

    public void StartGame()
    {
        gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
        inGameOverlay.gameObject.SetActive(true);
    }

    internal void Dead()
    {
        gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        inGameOverlay.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetCoinCount(int coins)
    {
        coinCount.text = $"{coins} Coins";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
