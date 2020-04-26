using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 2.0f;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI gameOverTxt;
    private int score = 0;
    public bool isGameActive;
    public Button restartButton;
    public GameObject tittleScreen;

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTxt.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverTxt.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= (difficulty - .5f);
        StartCoroutine(SpawnTarget());
        scoreTxt.text = "Score: " + score;
        tittleScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
