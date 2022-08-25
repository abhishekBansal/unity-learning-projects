using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1f;
    public bool isGameActive = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private int score;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(spawnTargets());
        scoreText.text = "Score: " + score;
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTargets() {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void gameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
