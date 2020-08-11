using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public CubeScript player;

    public GameObject coin;
    public GameObject grenade;
    public GameObject enemy;
    public int amountOfCoins;
    public int amountOfGrenades;
    public int amountOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        var random = new System.Random();
        
        // generate the coins
        for (int i = 0; i < amountOfCoins; i++)
        {
            float x = random.Next(20, 400);
            float z = random.Next(20, 400);

            Instantiate(coin, new Vector3(x, 150, z), Quaternion.identity);
        }

        // generate grenades
        for (int i = 0; i < amountOfGrenades; i++)
        {
            float x = random.Next(20, 400);
            float z = random.Next(20, 400);

            Instantiate(grenade, new Vector3(x, 150, z), Quaternion.identity);
        }

        // generate enemies
        for (int i = 0; i < amountOfEnemies; i++)
        {
            float x = random.Next(20, 400);
            float z = random.Next(20, 400);

            var enemyScript = Instantiate(enemy, new Vector3(x, 150, z), Quaternion.identity).GetComponent<EnemyScript>();
            enemyScript.Player = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
