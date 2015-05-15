using UnityEngine;
using System.Collections;

public class AnimationActivator : MonoBehaviour 
{
    private static string[] anims;
    private Animator _animator = null;

	void Start () 
    {
	    if(AnimationActivator.anims == null)
        {
            AnimationActivator.anims = new string[2];
            AnimationActivator.anims[0] = "anim1";
            AnimationActivator.anims[1] = "anim2";
        }
	}
	
	void Update () 
    {
	
	}

    public void PlayMessageAnim()
    {
        if(this._animator == null)
        {
            this._animator = this.GetComponent<Animator>();
        }
        if(this._animator != null)
        {
            this._animator.SetTrigger(AnimationActivator.anims[Random.Range(0, AnimationActivator.anims.Length)]);
        }
    }
}
