using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static bool CanSpawnEnemy;
    public static int WaveCount;
    public static bool SpawnHorde;
    public GameObject enemy;
    public GameObject boss;
    private bool BossActive;
    private bool EnemyIncrease;

    //Spawn one enemy
    private void Start()
    {
        EnemyIncrease = true;
        CanSpawnEnemy = true;
        WaveCount = 0;
    }

    private void Update()
    {
        if (CanSpawnEnemy)
            //If the enemy wave is killed
            if (FindObjectOfType<Enemy>() == null)
            {
                //i nemici continuano ad aumentare fino all'ondata 14
                if (EnemyIncrease) WaveCount += 1;


                //if on wave 14 disable enemy increase
                if (WaveCount >= 14)
                {
                    //Activate barriers
                    Player.PacmanEffect = false;
                    EnemyIncrease = false;
                }


                //then increase enemy and player speed
                if (!EnemyIncrease && WaveCount < 20)
                {
                    Player.runSpeed += 1;
                    Enemy.EnemySpeed += 0.25f;
                }


                Spawn(WaveCount);
            }


        if (WaveCount >= 20)
        {
            CanSpawnEnemy = false;
            if (!BossActive)
            {
                BossActive = true;
                Weapon.maxbulletallowed = 35;
                Instantiate(boss, BigBoi.BossStartPosition, Quaternion.identity);
            }
        }

        if (SpawnHorde)
            if (FindObjectOfType<Enemy>() == null)
            {
                Spawn(Random.Range(3, 6));
                SpawnHorde = false;
            }
    }

    //Spawn enemy on random coordinates. Coordinates are regenerated for every Enemy instance

    public void Spawn(int waveSize)
    {
        for (var i = 0; i < waveSize; i++)
        {
            float RandX = Random.Range(3, 12);
            float RandY = Random.Range(-4, 6);
            var whereToSpawn = new Vector2(RandX, RandY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}