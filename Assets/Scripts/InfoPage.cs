using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoPage : MonoBehaviour
{
    public Text VersionInfoText;
    private readonly string VersionInfo = "Development release v2.0";

    private void Update()
    {
        VersionInfoText.text = VersionInfo;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}