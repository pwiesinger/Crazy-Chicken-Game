using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float degreesPerSecond = 15f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    bool up = true;

    // Position Storage Variables
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // spin around Y Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down
        //tempPos = transform.position;
        //var value = Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

        //if (up)
        //{
        //    tempPos.y += value;
        //}
        //else
        //{
        //    tempPos.y -= value;
        //}

        //up = !up;

        //transform.position = tempPos;

    }
}
