using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private List<GameObject> bubbles;
    [SerializeField] private float startingScale;
    private float speed = 0.0f;
    private float counter = 0.0f;


    public void Grow(float acceleration)
    {
        if (speed+acceleration < maxSpeed)
        {
            speed += acceleration;
        }
    }

    private void Update()
    {
        speed = Mathf.Max(speed-0.0002f,0f);
        counter += Time.deltaTime;
        float currentSpeed = speed * Curves.Sinus(counter/2);
        for(int i = 0; i < bubbles.Count; ++i)
        {
            if (bubbles[i].transform.localScale.x + currentSpeed >= startingScale && bubbles[i].transform.localScale.x + currentSpeed <= startingScale * 3)
            {
                bubbles[i].transform.localScale += currentSpeed * Vector3.one;
            }
        }
    }
}
