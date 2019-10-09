using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementControl : MonoBehaviour
{

    public float[] displacementAmount;
    public ParticleSystem explosionParticles;
    MeshRenderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
        displacementAmount = new float[meshRender.materials.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < displacementAmount.Length; ++i)
        {
            displacementAmount[i] = Mathf.Lerp(displacementAmount[i], 0, Time.deltaTime);
            meshRender.materials[i].SetFloat("_Amount", displacementAmount[i]);
        }
    }

    public void Squeeze()
    {
        for (int i = 0; i < displacementAmount.Length; ++i) {
            displacementAmount[i] = 0.1f;
        }
        //explosionParticles.Play();
    }
}
