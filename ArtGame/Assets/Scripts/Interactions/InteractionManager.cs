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
            Transformations.Instance.StartVanish();
        }
        if (Input.GetButton("2"))
        {
            Transformations.Instance.Rotate(1f);
        }
        if (Input.GetButton("3"))
        {

        }
        if (Input.GetButton("4"))
        {

        }
        if (Input.GetButton("5"))
        {

        }
    }
}
