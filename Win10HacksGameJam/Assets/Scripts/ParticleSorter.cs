using UnityEngine;
using System.Collections;

public class ParticleSorter : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        //Change particle sorting layer
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Particles";
    }
}
