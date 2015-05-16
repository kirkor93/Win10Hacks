using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    private Text guiText;

	// Use this for initialization
	void Start () {
        this.guiText = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        this.guiText.text = "Score: " + GameManager.Instance.GetCash().ToString() + " $";
	}
}
