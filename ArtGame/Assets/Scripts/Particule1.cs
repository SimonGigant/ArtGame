using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;


public class Particule1 : MonoBehaviour

{

    public ParticleSystem[] p;
    
    public VisualEffect vfx2;
    public VisualEffect vfx;



    // Update is called once per frame
    void Update()
    {

    if (Input.GetKeyDown(KeyCode.A))
    {
        p[0].Play();
    }

    if (Input.GetKeyUp(KeyCode.A))
    {
       p[0].Stop();
    }

    if (Input.GetKeyDown(KeyCode.Z))
        {
            p[1].Play();
        }

    if (Input.GetKeyUp(KeyCode.Z))
        {
            p[1].Stop();
        }


    if (Input.GetKeyDown(KeyCode.E))
        {
            p[2].Play();
        }

    if (Input.GetKeyUp(KeyCode.E))
        {
            p[2].Stop();
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            p[3].Play();
        }

    if (Input.GetKeyUp(KeyCode.R))
        {
            p[3].Stop();
        }

    if (Input.GetKeyDown(KeyCode.T))
        {
            vfx.Play();

        }
        else
        {
            vfx.Reinit();
        }


       /*if (Input.GetKeyDown(KeyCode.T))
        {
            p5.Play();
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            p5.Stop();
        }




        if (Input.GetKeyDown(KeyCode.Y))
        {
            p6.Play();
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            p6.Stop();
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            p7.Play();
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            p7.Stop();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            p8.Play();
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            p8.Stop();
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            p9.Play();
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            p9.Stop();
        }*/

    }
}
