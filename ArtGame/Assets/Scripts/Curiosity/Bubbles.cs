using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 0f;
    [SerializeField] private List<GameObject> bubbles = null;
    [SerializeField] private float startingScale = 0.5f;
    private float maxRotationSpeed = 100.0f;
    private float currentRotSpeed = 0.0f;
    private float speed = 0.0f;
    private float counter = 0.0f;
    

    public void Grow(float acceleration)
    {
        if (speed+acceleration < maxSpeed)
        {
            speed += acceleration;
        }
    }

    public void Squeeze()
    {
        for(int i = 0; i < bubbles.Count; ++i)
        {
            bubbles[i].GetComponent<DisplacementControl>().Squeeze();
        }
    }

    public void Rotate(float acceleration)
    {
        if (acceleration > 0)
        {
            currentRotSpeed = Mathf.Min(currentRotSpeed + acceleration, maxRotationSpeed);
        }
        else
        {
            currentRotSpeed = Mathf.Max(currentRotSpeed + acceleration, -maxRotationSpeed);
        }
    }

    private void Update()
    {
        speed = Mathf.Max(speed-0.0002f,0f);
        counter += Time.deltaTime;
        float currentSpeed = speed * Curves.Sinus(counter/3);
        for(int i = 0; i < bubbles.Count; ++i)
        {
            if (bubbles[i].transform.localScale.x + currentSpeed >= startingScale && bubbles[i].transform.localScale.x + currentSpeed <= startingScale * 2.5)
            {
                bubbles[i].transform.localScale += currentSpeed * Vector3.one;
            }
        }


        transform.Rotate(new Vector3(3f,2f,5f).normalized, currentRotSpeed * Time.deltaTime);
        if (currentRotSpeed > 0.01f || currentRotSpeed < -0.01f)
        {
            bool signBefore = currentRotSpeed > 0.0f;
            currentRotSpeed -= 0.2f * currentRotSpeed / Mathf.Abs(currentRotSpeed);
            bool signAfter = currentRotSpeed > 0.0f;
            if ((signBefore && !signAfter) || (!signBefore && signAfter))
            {
                currentRotSpeed = 0.0f;
            }
        }
    }
}
