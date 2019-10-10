using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public float force = 3f;
    public float forceOffset = 0.1f;
    [SerializeField] private ParticleSystem particles;
    public FadeIn fade;

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
                yield return new WaitForSeconds(1);
                FirstGrowMoon(2);
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
        fade.Fade();
    }

    public void Squeeze()
    {
        GetComponentInChildren<DisplacementControl>().Squeeze();
    }

    public void StartVanish()
    {
        StartCoroutine("Vanish");
        fade.FadeOut();
    }

    public void Rotate(float acceleration)
    {
        if (acceleration > 0)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration, maxSpeed);
        }else
        {
            currentSpeed = Mathf.Max(currentSpeed + acceleration, -maxSpeed);
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

    public void RotateBubbles(int i, float acceleration)
    {
        if (i < bubbles.Count) {
            bubbles[i].GetComponent<Bubbles>().Rotate(acceleration);
        }
    }

    public void GrowBubble(int i, float acceleration)
    {
        if (i < bubbles.Count)
        {
            bubbles[i].GetComponent<Bubbles>().Grow(acceleration);
            bubbles[i].GetComponent<Bubbles>().Squeeze();
        }
    }

    public void Update()
    {
        transform.Rotate(Vector3.up, (currentSpeed + 10f) * Time.deltaTime);
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

    public void DisformSphere(float intensity = 1f)
    {
        Vector3 dir = new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Ray inputRay = new Ray(transform.position-dir*3,dir);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer)
            {
                Vector3 point = hit.point;
                point += hit.normal * forceOffset;
                deformer.AddDeformingForce(point, force * intensity);
            }
        }
    }

    public void PunctualDisform(float intensity = 1f)
    {
        Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Ray inputRay = new Ray(transform.position - dir * 3, dir);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer)
            {
                Vector3 point = hit.point;
                point += hit.normal * forceOffset;
                deformer.AddDeformingForce(point, 50f * intensity);
            }
        }
    }

    public void Particle()
    {
        particles.Play();
    }
}
