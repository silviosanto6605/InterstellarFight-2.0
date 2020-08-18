using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private static bool GameEnded;
    public GameObject GameOverUI;

    private void Start()
    {
        GameEnded = false;
    }

    private void Update()
    {
        if (Player.health <= 0) HaveLost();

        if (GameEnded) GameOverUI.SetActive(true);
    }

    //Called after game over

    public static void HaveLost()
    {
        /*destroy rigidbody*/

        Destroy(GameObject.Find("Player") /*, GameObject.Find("Player").GetComponent<AudioSource>().clip.length*/);
        Time.timeScale = 0f;
        SpawnSystem.CanSpawnEnemy = false;
        GameEnded = true;
    }

    //Restart game

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        GameOverUI.SetActive(false);
        GameEnded = false;
        Time.timeScale = 1f;
        Score.score = 0;
        Player.health = 3;
    }
}