using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{

    public float speed = 3f;
    public Transform car1;

    public Transform car1target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        car1.Translate(Vector3.forward * speed * Time.deltaTime);
        car1.LookAt(car1target);
    }
}
