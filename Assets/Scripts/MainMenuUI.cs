using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public void StartGame () {

        SceneManager.LoadScene ("Main");
        Time.timeScale = 1f;
        Score.score = 0;
        Player.health = 3;

    }

    public void MoreInfo () {

        SceneManager.LoadScene ("InfoPage");

    }
}