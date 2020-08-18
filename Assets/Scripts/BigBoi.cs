using UnityEngine;

public class BigBoi : MonoBehaviour
{
    public static Vector3 BossStartPosition = new Vector3(16.6f, 0, 0);
    public GameObject MissilePrefab;
    public GameObject BombPrefab;
    public GameObject FirePoint;
    public GameObject enemy;

    private Animator anim;
    private bool startanimplayed;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!startanimplayed)
            //if animation is played destroy animator, in order to make the boss move
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                anim.StopPlayback();
                Invoke("Attack", 3);
                startanimplayed = true;
            }
    }

    private void Attack()
    {
        var RandomAttack = Random.Range(1, 4);

        void ShootMissiles()
        {
            if (FindObjectOfType<Missile>() == null)
                for (var x = 0; x < Random.Range(2, 5); x++)
                {
                    float RandX = Random.Range(3, 12);
                    float RandY = Random.Range(-4, 6);
                    var whereToSpawn = new Vector2(RandX, RandY);
                    Instantiate(MissilePrefab, whereToSpawn, Missile.MissileRotation);
                }
        }

        void LaunchBombs()
        {
            if (FindObjectOfType<Bomb>() == null)
                for (var x = 0; x < Random.Range(2, 5); x++)
                {
                    float RandX = Random.Range(3, 12);
                    float RandY = Random.Range(-4, 6);
                    var whereToSpawn = new Vector2(RandX, RandY);
                    Instantiate(BombPrefab, whereToSpawn, Quaternion.identity);
                }
        }


        switch (RandomAttack)
        {
            case 1:

                ShootMissiles();
                break;

            case 2:
                SpawnSystem.SpawnHorde = true;
                break;


            case 3:

                LaunchBombs();
                break;
        }


        Invoke("Attack", 3);
    }
}