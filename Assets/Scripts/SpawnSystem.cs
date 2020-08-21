using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    public static bool CanSpawnEnemy;
    private static int enemyCount;
    private static int WaveCount;
    public static bool SpawnHorde;
    public GameObject enemy;
    public GameObject boss;
    private bool bossactive = false;
    private bool EnemyIncrease;

    //SpawnEnemy one enemy
    private void Start()
    {
        EnemyIncrease = true;
        CanSpawnEnemy = false;
        enemyCount = 25;
        WaveCount = enemyCount;
    }

    private void Update()
    {

        //If the enemy wave is killed
        if (FindObjectOfType<Enemy>() == null)
        {

            //...fino all'ondata 14
            if (WaveCount >= 14)
            {
                //Activate barriers
                Player.PacmanEffect = false;
                EnemyIncrease = false;
            }

            if (WaveCount >= 20)
            {
                CanSpawnEnemy = false;
                if (!bossactive)
                {
                    
                    Weapon.maxbulletallowed = 35;
                    Instantiate(boss, BigBoi.BossStartPosition, Quaternion.identity);
                    bossactive = true;
                }

            }

            if (SpawnHorde)
                if (FindObjectOfType<Enemy>() == null)
                {
                    SpawnEnemy(Random.Range(3, 6));
                    SpawnHorde = false;
                }
            
            NextWave();
        }
    }


    private void NextWave()
    {
        if (CanSpawnEnemy)
        {
            
            Weapon.bullet_shooted -= 10;
            WaveCount += 1;
            if (EnemyIncrease) enemyCount += 1;
            SpawnEnemy(enemyCount);
        }
           
    }

    private void SpawnEnemy(int waveSize)
    {
        if (CanSpawnEnemy)
            for (var i = 0; i < waveSize; i++)
            {
                float RandX = Random.Range(5, 18);
                float RandY = Random.Range(-4, 6);
                var whereToSpawn = new Vector2(RandX, RandY);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
            }
    }
}