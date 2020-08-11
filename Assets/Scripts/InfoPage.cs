using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoPage : MonoBehaviour {
    private string VersionInfo = "Development release v2.0";
    public Text VersionInfoText;

    void Update () {
        VersionInfoText.text = VersionInfo;
    }

    public void ToMenu () {

        SceneManager.LoadScene ("Main Menu");

    }

}