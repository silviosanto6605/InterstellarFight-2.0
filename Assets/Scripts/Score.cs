using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int score;
    public Text scoretext;

    void Start () {
        score = 0;
        scoretext.text = "Punti: " + score.ToString ();
    }

    //Change  text color based on score
    private void Update () {

        scoretext.text = "Punti: " + score.ToString ();

        if (score > 1500) {
            SpawnSystem.CanSpawnEnemy = false;
            //Spawn boss

        }

    }

}