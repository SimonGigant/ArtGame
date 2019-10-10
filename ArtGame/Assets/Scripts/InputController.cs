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
    public ParticleSystem[] p;


    private void Start()
    {
        Transformations.Instance.Begin();
    }

    void Update()
    {
        // C3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3C", 16)))
        {
            InteractionManager.Instance.sounds[0].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("3C", 16)) > 0)
        {
            //Transformations.Instance.Rotate(-1f);
            Transformations.Instance.DisformSphere(3f);
        }
        // C3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("3C", 16)))
        {
            InteractionManager.Instance.sounds[0].Stop();
        }
        // D3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3E", 16)))
        {
            InteractionManager.Instance.sounds[1].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("3E", 16)) > 0)
        {
            Transformations.Instance.RotateBubbles(0, 30f);
            Transformations.Instance.GrowForms(0, 0.01f);
            Transformations.Instance.GrowForms(1, 0.01f);
            Transformations.Instance.GrowBubble(1, 0.0005f);
        }
        // D3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("3E", 16)))
        {
            InteractionManager.Instance.sounds[1].Stop();
        }
        // E3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("40", 16)))
        {
            InteractionManager.Instance.sounds[2].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("40", 16)) > 0)
        {
            Transformations.Instance.Squeeze();
            Transformations.Instance.GrowBubble(0, 0.0005f);
        }
        // E3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("40", 16)))
        {
            InteractionManager.Instance.sounds[2].Stop();
        }
        // F3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("41", 16)))
        {
            InteractionManager.Instance.sounds[3].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("41", 16)) > 0)
        {
            Transformations.Instance.RotateBubbles(0, 30f);
            p[2].Play();
        }
        // F3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("41", 16)))
        {
            InteractionManager.Instance.sounds[3].Stop();
        }
        // G3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("43", 16)))
        {
            InteractionManager.Instance.sounds[4].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("43", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(1, -0.001f);
            Transformations.Instance.GrowForms(2, 0.01f);
            Transformations.Instance.GrowBubble(3, 0.0005f);
        }
        // G3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("43", 16)))
        {
            InteractionManager.Instance.sounds[4].Stop();
        }
        // A3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("45", 16)))
        {
            InteractionManager.Instance.sounds[5].Play();
            p[0].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("45", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowForms(0, 0.02f);

        }
        // A3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("45", 16)))
        {
            InteractionManager.Instance.sounds[5].Stop();
            p[0].Stop();
        }
        // B3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("47", 16)))
        {
            InteractionManager.Instance.sounds[6].Play();
            p[4].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("47", 16)) > 0)
        {
            Transformations.Instance.RotateBubbles(3, 25f);
            Transformations.Instance.RotateBubbles(1, -15f);
            Transformations.Instance.GrowBubble(2, 0.0005f);
        }
        // B3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("47", 16)))
        {
            InteractionManager.Instance.sounds[6].Stop();
        }// C4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("48", 16)))
        {
            InteractionManager.Instance.sounds[7].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("48", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(1, 0.001f);
            Transformations.Instance.GrowForms(1, 0.02f);
        }
        // C4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("48", 16)))
        {
            InteractionManager.Instance.sounds[7].Stop();
        }
        // D4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4A", 16)))
        {
            InteractionManager.Instance.sounds[8].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4A", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowMoon(1, 0.001f);
            Transformations.Instance.GrowMoon(2, 0.001f);
            Transformations.Instance.GrowBubble(3, 0.0005f);
            p[1].Play();
        }
        // D4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4A", 16)))
        {
            InteractionManager.Instance.sounds[8].Stop();
        }
        // E4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4C", 16)))
        {
            InteractionManager.Instance.sounds[9].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4C", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowMoon(2, 0.001f);
            Transformations.Instance.PunctualDisform(-25, 20, 2, 0.1f);
        }
        // E4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4C", 16)))
        {
            InteractionManager.Instance.sounds[9].Stop();
        }
        // F4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4D", 16)))
        {
            InteractionManager.Instance.sounds[10].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4D", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(3, -0.001f);
            Transformations.Instance.GrowMoon(1, -0.001f);
        }
        // F4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4D", 16)))
        {
            InteractionManager.Instance.sounds[10].Stop();
        }
        // G4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4F", 16)))
        {
            InteractionManager.Instance.sounds[11].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4F", 16)) > 0)
        {
            Transformations.Instance.RotateBubbles(3, 12f);
            Transformations.Instance.GrowForms(2, 0.02f);
        }
        // G4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4F", 16)))
        {
            InteractionManager.Instance.sounds[11].Stop();
        }
        // A4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("51", 16)))
        {
            InteractionManager.Instance.sounds[12].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("51", 16)) > 0)
        {
            Transformations.Instance.GrowMoon(3, 0.001f);
            Transformations.Instance.GrowMoon(2, -0.001f);
            Transformations.Instance.GrowBubble(0, 0.0005f);
        }
        // A4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("51", 16)))
        {
            InteractionManager.Instance.sounds[12].Stop();
        }
        // B4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("53", 16)))
        {
            InteractionManager.Instance.sounds[13].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("53", 16)) > 0)
        {
            //Transformations.Instance.RotateBubbles(3, -20f);
            //Transformations.Instance.RotateBubbles(2, 15f);
            //Transformations.Instance.GrowForms(3, 0.005f);
        }
        // B4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("53", 16)))
        {
            InteractionManager.Instance.sounds[13].Stop();
        }
        // C5
        if (MidiMaster.GetKeyDown(Convert.ToInt32("54", 16)))
        {
            InteractionManager.Instance.sounds[14].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("54", 16)) > 0)
        {
            Transformations.Instance.DisformSphere();
            Transformations.Instance.RotateBubbles(1, -20f);
        }
        // C5
        if (MidiMaster.GetKeyUp(Convert.ToInt32("54", 16)))
        {
            InteractionManager.Instance.sounds[14].Stop();
        }


        // C#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3D", 16)))
        {
            Transformations.Instance.PunctualDisform(3f);
            InteractionManager.Instance.percus[0].Play();
        }
        // D#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3F", 16)))
        {
            InteractionManager.Instance.percus[1].Play();
            Transformations.Instance.Particle();
        }
        // F#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("42", 16)))
        {
            Transformations.Instance.PunctualDisform(2f);
            InteractionManager.Instance.percus[2].Play();
        }
        // G#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("44", 16)))
        {
            InteractionManager.Instance.percus[3].Play();
            Transformations.Instance.Squeeze();
            Transformations.Instance.PunctualDisform();
        }
        // A#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("46", 16)))
        {
            InteractionManager.Instance.percus[4].Play();
            Transformations.Instance.Squeeze();
        }
        // C#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("49", 16)))
        {
            InteractionManager.Instance.percus[5].Play();
            Transformations.Instance.Rotate(-30f);
            p[5].Play();
        }

        if (MidiMaster.GetKey(Convert.ToInt32("49", 16)) > 0)
        {  
          
        }

        if (MidiMaster.GetKeyUp(Convert.ToInt32("49", 16)))
        {
           
        }

        // D#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4B", 16)))
        {
            InteractionManager.Instance.percus[6].Play();
            Transformations.Instance.Particle();
            Transformations.Instance.PunctualDisform(1.5f);
        }
        // F#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4E", 16)))
        {
            InteractionManager.Instance.percus[7].Play();
            Transformations.Instance.PunctualDisform(1f);
        }
        // G#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("50", 16)))
        {
            InteractionManager.Instance.percus[8].Play();
            Transformations.Instance.Rotate(50f);
        }
        // A#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("52", 16)))
        {
            InteractionManager.Instance.percus[9].Play();
            Transformations.Instance.Squeeze();
        }
    }
}
