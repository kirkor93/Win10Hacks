using UnityEngine;
using System.Collections;

public class LineManager : MonoBehaviour 
{
    [SerializeField]
    private Lane laneGO = null;

    [SerializeField]
    private Texture2D textureOdd = null;
    [SerializeField]
    private Texture2D textureEven = null;

    public void ResetLaneManager(int laneAmount)
    {
        for(int i = 0;i < laneAmount;++i)
        {

        }
    }

	void Start () 
    {
        
	}
	
	void Update () 
    {
	
	}
}
