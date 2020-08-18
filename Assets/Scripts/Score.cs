using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoretext;

    private void Start()
    {
        score = 0;
        scoretext.text = "Score: " + score;
    }

    //Change  text color based on score
    private void Update()
    {
        scoretext.text = "Score: " + score;

        if (score > 1500) SpawnSystem.CanSpawnEnemy = false;
    }
}