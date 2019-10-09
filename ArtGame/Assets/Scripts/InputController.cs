using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;


public class InputController : MonoBehaviour
{
    public CubeSphere planet;
    public MeshDeformer md;
    public MeshDeformerInput mdi;

    void Update()
    {
        
        if(MidiMaster.GetKeyDown(Convert.ToInt32("3C", 16))) //format "Quand la touche est enfoncée"
        {
            md.springForce = 2;
            mdi.force = 40;
        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("3E", 16)))
        {
            md.springForce = 5;
            mdi.force = 30;
        }

        if (MidiMaster.GetKey(Convert.ToInt32("40", 16)) > 0)   //format "Tant que la touche est enfoncée"
        {

        }

        if (MidiMaster.GetKeyUp(Convert.ToInt32("41", 16))) //format "Quand la touche est relachée"
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("43", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("45", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("47", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("48", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("4A", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("4C", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("4D", 16)))
        {

        }

        if (MidiMaster.GetKeyDown(Convert.ToInt32("4F", 16)))
        {

        }
    }
}
