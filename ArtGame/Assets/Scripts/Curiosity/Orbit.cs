using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dir, 3f * Time.deltaTime);
    }
}
