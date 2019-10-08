using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    public static Transformations _instance;
    public static Transformations Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public AnimationCurve softCurve;

    public List<GameObject> lights;
    public List<GameObject> globalLights;
    public List<GameObject> moons;
    public float growDuration;
    public float basicSize;
    public bool isGrowing = false;
    public float currentSpeed;
    public float maxSpeed;
    [SerializeField] private List<GameObject> bubbles;

    public void Start()
    {
        for(int i = 0; i < globalLights.Count; ++i)
        {
            //globalLights[i].GetComponent<Light>().intensity = 0f;
        }
        transform.localScale = Vector3.zero;
    }

    private IEnumerator Grow()
    {
        isGrowing = true;
        float count = 0f;
        for (; ; )
        {
            transform.localScale = softCurve.Evaluate(count / growDuration)* basicSize * Vector3.one;
            count += Time.deltaTime;
            if (count < growDuration)
            {
                yield return null;
            }
            else
            {
                transform.localScale = basicSize * Vector3.one;
                FirstGrowMoon(0);
                yield return new WaitForSeconds(1);
                FirstGrowMoon(1);
                break;
            }
        }
        isGrowing = false;
    }

    private IEnumerator Vanish()
    {
        isGrowing = true;
        float count = 0f;
        for (; ; )
        {
            transform.localScale = (1-softCurve.Evaluate(count / growDuration)) * basicSize * Vector3.one;
            count += Time.deltaTime;
            if (count < growDuration)
            {
                yield return null;
            }
            else
            {
                transform.localScale = Vector3.zero;
                break;
            }
        }
        isGrowing = false;
    }

    public void Begin()
    {
        StartCoroutine("Grow");
    }

    public void StartVanish()
    {
        StartCoroutine("Vanish");
    }

    public void Rotate(float acceleration)
    {
        if (acceleration > 0)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration, maxSpeed);
        }else
        {
            currentSpeed = Mathf.Max(currentSpeed - acceleration, -maxSpeed);
        }
    }

    public bool FirstGrowMoon(int i)
    {
        if (i < moons.Count && moons[i].transform.localScale.x < 0.01)
        {
            return moons[i].GetComponent<Moons>().StartGrowing();
        }
        return false;
    }

    public void GrowMoon(int i, float speed)
    {
        if (i < moons.Count && !moons[i].GetComponent<Moons>().isGrowing)
        {
            moons[i].GetComponent<Moons>().Grow(speed);
        }
    }

    public void GrowForms(int i, float speed)
    {
        moons[i].GetComponent<Moons>().GrowForms(speed);
    }

    public void GrowBubble(int i, float acceleration)
    {
        if (i < bubbles.Count)
        {
            bubbles[i].GetComponent<Bubbles>().Grow(acceleration);
        }
    }

        public void Update()
    {
        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
        if (currentSpeed > 0.01f || currentSpeed < -0.01f)
        {
            bool signBefore = currentSpeed > 0.0f;
            currentSpeed -= 0.5f*currentSpeed / Mathf.Abs(currentSpeed);
            bool signAfter = currentSpeed > 0.0f;
            if ((signBefore && !signAfter)|| (!signBefore && signAfter))
            {
                currentSpeed = 0.0f;
            }
        }
    }
}
