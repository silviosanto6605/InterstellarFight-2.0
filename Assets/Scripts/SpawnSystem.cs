using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static bool CanSpawnEnemy;
    public GameObject enemy;
    public static int WaveCount;
    private bool EnemyIncrease;
    public GameObject boss;
    public static bool SpawnHorde = false;
    private bool BossActive = false;

    //Spawn one enemy
    private void Start()
    {
        EnemyIncrease = false;
        CanSpawnEnemy = false;
        WaveCount = 0;
    }

    //Spawn enemy on random coordinates. Coordinates are regenerated for every Enemy instance

    public void Spawn(int waveSize)
    {
        for (int i = 0; i < waveSize; i++)
        {
            float RandX = Random.Range(3, 12);
            float RandY = Random.Range(-4, 6);
            Vector2 whereToSpawn = new Vector2(RandX, RandY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }

    }

    private void Update()
    {

        if (CanSpawnEnemy)
        {

            //If the enemy wave is killed
            if (FindObjectOfType<Enemy>() == null)
            {
                //i nemici continuano ad aumentare fino all'ondata 14
                if (EnemyIncrease)
                {
                    WaveCount += 1;
                }


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




        }


        if (WaveCount >= 20)
        {
            CanSpawnEnemy = false;
            if (!BossActive)
            {
                BossActive = true;
                Weapon.maxbulletallowed = 30;
                Instantiate(boss, BigBoi.BossStartPosition, Quaternion.identity);









            }

        }

        if (SpawnHorde)
        {
            if (FindObjectOfType<Enemy>() == null)
            {
                Spawn(Random.Range(3, 6));
                SpawnHorde = false;
            }



        }




    }
}
