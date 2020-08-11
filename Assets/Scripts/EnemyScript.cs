using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed;
    public int MaxDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}
