using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMove : MonoBehaviour
{
    private float counter = 0f;
    private Vector3 begin;

    private void Start()
    {
        begin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        transform.position = begin + Vector3.forward * Curves.Sinus(counter / 4) * 0.5f;
    }
}
