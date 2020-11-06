using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockForGridLevel : MonoBehaviour
{
    public float speed = 1f;

    public float timer;
    public float changeTime = 1f;

    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= changeTime)
        {
            speed = -speed;
            timer = 0f;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
