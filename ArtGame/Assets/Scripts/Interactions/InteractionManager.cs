using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager _instance;
    public static InteractionManager Instance { get { return _instance; } }
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

    public void Update()
    {
        if (Input.GetButton("0"))
        {
            Transformations.Instance.Begin();
        }
        if (Input.GetButton("1"))
        {
            //Transformations.Instance.StartVanish();
            Transformations.Instance.GrowBubble(0,0.0005f);
        }
        if (Input.GetButton("2"))
        {
            Transformations.Instance.Rotate(1f);
        }
        if (Input.GetButton("3"))
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowMoon(1, -0.001f);
        }
        if (Input.GetButton("4"))
        {
            Transformations.Instance.GrowMoon(1, 0.001f);
            Transformations.Instance.GrowMoon(0, -0.001f);
            Transformations.Instance.GrowBubble(1, 0.0005f);
        }
        if (Input.GetButton("5"))
        {
            Transformations.Instance.GrowForms(0,0.01f);
            Transformations.Instance.GrowForms(1, 0.01f);
        }
    }
}
