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
    public bool begin = true;
    public float counter = 0.0f;
    public ParticleSystem[] p;


    private void Start()
    {

    }

    void Update()
    {
        if (!begin)
        {
            counter += Time.deltaTime;
        }
        if (counter > 15f)
        {
            Transformations.Instance.StartVanish();
        }
        // C3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3C", 16)) || Input.GetButtonDown("0"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[0].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("3C", 16)) > 0 || Input.GetButton("0"))
        {
            //Transformations.Instance.Rotate(-1f);
            Transformations.Instance.DisformSphere(3f);
            counter = 0f;
        }
        // C3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("3C", 16)) || Input.GetButtonUp("0"))
        {
            InteractionManager.Instance.sounds[0].Stop();
        }
        // D3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3E", 16)) || Input.GetButtonDown("1"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[1].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("3E", 16)) > 0 || Input.GetButton("1"))
        {
            Transformations.Instance.RotateBubbles(0, 30f);
            Transformations.Instance.GrowForms(0, 0.01f);
            Transformations.Instance.GrowForms(1, 0.01f);
            Transformations.Instance.GrowBubble(1, 0.0005f);
            counter = 0f;
        }
        // D3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("3E", 16)) || Input.GetButtonUp("1"))
        {
            InteractionManager.Instance.sounds[1].Stop();
        }
        // E3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("40", 16)) || Input.GetButtonDown("2"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[2].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("40", 16)) > 0 || Input.GetButton("2"))
        {
            Transformations.Instance.Squeeze();
            Transformations.Instance.GrowBubble(0, 0.0005f);
            counter = 0f;
        }
        // E3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("40", 16)) || Input.GetButtonUp("2"))
        {
            InteractionManager.Instance.sounds[2].Stop();
        }
        // F3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("41", 16)) || Input.GetButtonDown("3"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[3].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("41", 16)) > 0 || Input.GetButton("3"))
        {
            Transformations.Instance.RotateBubbles(0, 30f);
            counter = 0f;
            p[2].Play();
        }
        // F3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("41", 16)) || Input.GetButtonUp("3"))
        {
            InteractionManager.Instance.sounds[3].Stop();
        }
        // G3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("43", 16)) || Input.GetButtonDown("4"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[4].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("43", 16)) > 0 || Input.GetButton("4"))
        {
            Transformations.Instance.GrowMoon(1, -0.001f);
            Transformations.Instance.GrowForms(2, 0.01f);
            Transformations.Instance.GrowBubble(3, 0.0005f);
            counter = 0f;
        }
        // G3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("43", 16)) || Input.GetButtonUp("4"))
        {
            InteractionManager.Instance.sounds[4].Stop();
        }
        // A3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("45", 16)) || Input.GetButtonDown("5"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[5].Play();
            p[0].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("45", 16)) > 0 || Input.GetButton("5"))
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowForms(0, 0.02f);
            counter = 0f;
        }
        // A3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("45", 16)) || Input.GetButtonUp("5"))
        {
            InteractionManager.Instance.sounds[5].Stop();
            p[0].Stop();
        }
        // B3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("47", 16)) || Input.GetButtonDown("6"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[6].Play();
            p[4].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("47", 16)) > 0 || Input.GetButton("6"))
        {
            Transformations.Instance.RotateBubbles(3, 25f);
            Transformations.Instance.RotateBubbles(1, -15f);
            Transformations.Instance.GrowBubble(2, 0.0005f);
            counter = 0f;
        }
        // B3
        if (MidiMaster.GetKeyUp(Convert.ToInt32("47", 16)) || Input.GetButtonUp("6"))
        {
            InteractionManager.Instance.sounds[6].Stop();
        }// C4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("48", 16)) || Input.GetButtonDown("7"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[7].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("48", 16)) > 0 || Input.GetButton("7"))
        {
            Transformations.Instance.GrowMoon(1, 0.001f);
            Transformations.Instance.GrowForms(1, 0.02f);
            counter = 0f;
        }
        // C4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("48", 16)) || Input.GetButtonUp("7"))
        {
            InteractionManager.Instance.sounds[7].Stop();
        }
        // D4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4A", 16)) || Input.GetButtonDown("8"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[8].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4A", 16)) > 0 || Input.GetButton("8"))
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowMoon(1, 0.001f);
            Transformations.Instance.GrowMoon(2, 0.001f);
            Transformations.Instance.GrowBubble(3, 0.0005f);
            counter = 0f;
            p[1].Play();
        }
        // D4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4A", 16)) || Input.GetButtonUp("8"))
        {
            InteractionManager.Instance.sounds[8].Stop();
        }
        // E4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4C", 16)) || Input.GetButtonDown("9"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[9].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4C", 16)) > 0 || Input.GetButton("9"))
        {
            Transformations.Instance.GrowMoon(0, 0.001f);
            Transformations.Instance.GrowMoon(2, 0.001f);
            counter = 0f;
            Transformations.Instance.PunctualDisform(-25, 20, 2, 0.1f);
        }
        // E4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4C", 16)) || Input.GetButtonUp("9"))
        {
            InteractionManager.Instance.sounds[9].Stop();
        }
        // F4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4D", 16)) || Input.GetButtonDown("10"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[10].Play();
            p[7].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4D", 16)) > 0 || Input.GetButton("10"))
        {
            Transformations.Instance.GrowMoon(3, -0.001f);
            Transformations.Instance.GrowMoon(1, -0.001f);
            counter = 0f;
        }
        // F4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4D", 16)) || Input.GetButtonUp("10"))
        {
            InteractionManager.Instance.sounds[10].Stop();
            p[7].Stop();
        }
        // G4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4F", 16)) || Input.GetButtonDown("11"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[11].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("4F", 16)) > 0 || Input.GetButton("11"))
        {
            Transformations.Instance.RotateBubbles(3, 12f);
            Transformations.Instance.GrowForms(2, 0.02f);
            counter = 0f;
        }
        // G4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("4F", 16)) || Input.GetButtonUp("11"))
        {
            InteractionManager.Instance.sounds[11].Stop();
        }
        // A4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("51", 16)) || Input.GetButtonDown("12"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[12].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("51", 16)) > 0 || Input.GetButton("12"))
        {
            Transformations.Instance.GrowMoon(3, 0.001f);
            Transformations.Instance.GrowMoon(2, -0.001f);
            Transformations.Instance.GrowBubble(0, 0.0005f);
            counter = 0f;
        }
        // A4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("51", 16)) || Input.GetButtonUp("12"))
        {
            InteractionManager.Instance.sounds[12].Stop();
        }
        // B4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("53", 16)) || Input.GetButtonDown("13"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[13].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("53", 16)) > 0 || Input.GetButton("13"))
        {
            Transformations.Instance.RotateBubbles(2, 15f);
            Transformations.Instance.GrowForms(3, 0.005f);
            counter = 0f;
        }
        // B4
        if (MidiMaster.GetKeyUp(Convert.ToInt32("53", 16)) || Input.GetButtonUp("13"))
        {
            InteractionManager.Instance.sounds[13].Stop();
        }
        // C5
        if (MidiMaster.GetKeyDown(Convert.ToInt32("54", 16)) || Input.GetButtonDown("14"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.sounds[14].Play();
        }
        if (MidiMaster.GetKey(Convert.ToInt32("54", 16)) > 0 || Input.GetButton("14"))
        {
            Transformations.Instance.DisformSphere();
            Transformations.Instance.RotateBubbles(1, -20f);
            counter = 0f;
        }
        // C5
        if (MidiMaster.GetKeyUp(Convert.ToInt32("54", 16)) || Input.GetButtonUp("14"))
        {
            InteractionManager.Instance.sounds[14].Stop();
        }


        // C#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3D", 16)) || Input.GetButtonDown("p1"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            Transformations.Instance.PunctualDisform(3f);
            InteractionManager.Instance.percus[0].Play();
            counter = 0f;
        }
        // D#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("3F", 16)) || Input.GetButtonDown("p2"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[1].Play();
            Transformations.Instance.Particle();
            counter = 0f;
        }
        // F#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("42", 16)) || Input.GetButtonDown("p3"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            Transformations.Instance.PunctualDisform(2f);
            InteractionManager.Instance.percus[2].Play();
            p[6].Play();
            counter = 0f;
        }
        // G#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("44", 16)) || Input.GetButtonDown("p4"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[3].Play();
            Transformations.Instance.Squeeze();
            Transformations.Instance.PunctualDisform();
            counter = 0f;
        }
        // A#3
        if (MidiMaster.GetKeyDown(Convert.ToInt32("46", 16)) || Input.GetButtonDown("p5"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[4].Play();
            Transformations.Instance.Squeeze();
            counter = 0f;
        }
        // C#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("49", 16)) || Input.GetButtonDown("p6"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[5].Play();
            Transformations.Instance.Rotate(-30f);
            counter = 0f;
            p[5].Play();
        }

        // D#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4B", 16)) || Input.GetButtonDown("p7"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[6].Play();
            Transformations.Instance.Particle();
            Transformations.Instance.PunctualDisform(1.5f);
            counter = 0f;
        }
        // F#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("4E", 16)) || Input.GetButtonDown("p8"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[7].Play();
            Transformations.Instance.PunctualDisform(1f);
            counter = 0f;
        }
        // G#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("50", 16)) || Input.GetButtonDown("p9"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[8].Play();
            Transformations.Instance.Rotate(50f);
            counter = 0f;
        }
        // A#4
        if (MidiMaster.GetKeyDown(Convert.ToInt32("52", 16)) || Input.GetButtonDown("p10"))
        {
            if (begin)
            {
                begin = false;
                Transformations.Instance.Begin();
            }
            InteractionManager.Instance.percus[9].Play();
            Transformations.Instance.Squeeze();
            counter = 0f;
        }
    }
}
