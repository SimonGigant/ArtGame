using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moons : MonoBehaviour
{
    public bool isGrowing = false;
    [SerializeField] private float growDuration = 1f;
    [SerializeField] private float maxSize = 1f;
    [SerializeField] private float minSize = 0f;
    [SerializeField] private List<GameObject> forms = null;
    [SerializeField] private GameObject orbit = null;
    private List<float> formScale = new List<float>();
    private float counterFormChange = 0.0f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        for(int i = 0; i < forms.Count; ++i)
        {
            formScale.Add(forms[i].transform.localScale.x);
        }
    }

    private void Update()
    {
    }

    public bool StartGrowing()
    {
        if (!isGrowing)
        {
            StartCoroutine("FirstGrow");
            return true;
        }
        return false;
    }

    private IEnumerator FirstGrow()
    {
        isGrowing = true;
        float count = 0f;
        for (;;)
        {
            transform.localScale = Transformations.Instance.softCurve.Evaluate(count / growDuration) * minSize * Vector3.one;
            count += Time.deltaTime;
            if (count < growDuration)
            {
                yield return null;
            }
            else
            {
                transform.localScale = minSize * Vector3.one;
                break;
            }
        }
        isGrowing = false;
    }

    public void GrowForms(float speed)
    {
        counterFormChange += Time.deltaTime;
        speed = speed * Curves.Sinus(counterFormChange);
        for(int i = 0; i < forms.Count; ++i)
        {
            GrowForm(i, speed);
        }
    }

    private void GrowForm(int i, float speed)
    {
        if (forms[i].transform.localScale.x + speed >= formScale[i] && forms[i].transform.localScale.x + speed <= formScale[i]*1.5) {
            forms[i].transform.localScale += speed * Vector3.one;
        }
    }

    public void Grow(float speed)
    {
        if(transform.localScale.x + speed < maxSize && transform.localScale.x + speed > minSize)
        {
            transform.localScale += speed * Vector3.one;
        }
    }
}
