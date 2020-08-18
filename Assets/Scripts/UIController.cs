using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    //Pause menu
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else if (!GameIsPaused) Pause();
        }
    }

    //Button methods below

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        GameIsPaused = false;
    }
}