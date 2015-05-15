using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RightPanelController : MonoBehaviour 
{
    [SerializeField]
    private WheelController _wheelController = null;

    [Header("Object References")]
    [Space(10)]
    [SerializeField]
    private Image _potImage = null;
    [SerializeField]
    private Text _potCouter = null;

    [Header("Parameters")]
    [Space(10)]
    public int _initialPotCount = 5;
    private int _potCount = 0;

    private float _currentPotProgres = 0.0f;
    public float _potProgresMultiplier = 0.002f;

    private static RightPanelController _instance;
    public static RightPanelController instance
    {
        get
        {
            return RightPanelController._instance;
        }
    }

    void Start()
    {
        RightPanelController._instance = this;

        if(this._wheelController == null)
        {
            this._wheelController = this.GetComponent<WheelController>();
            if(this._wheelController == null)
            {
                Debug.LogError("Missing reference to WheelController.");
            }
        }
        if(this._potImage == null)
        {
            Debug.LogError("Missing reference to pot image!");
        }
        if(this._potCouter == null)
        {
            Debug.LogError("Missing reference to pot counter!");
        }

        this._potCount = this._initialPotCount;
    }

    void Update()
    {
        ProcesPotCreation();
        ProcesPotIndicator();
    }

    void ProcesPotCreation()
    {
        this._currentPotProgres += this._wheelController.CurrentSpeed * this._potProgresMultiplier * Time.deltaTime;
        if(this._currentPotProgres > 1.0f)
        {
            this._currentPotProgres -= 1.0f;
            this._potCount += 1;
        }
    }
    void ProcesPotIndicator()
    {
        this._potImage.fillAmount = this._currentPotProgres;
        this._potCouter.text = "x " + this._potCount;
    }

    public bool GetPotToThrow()
    {
        if(this._potCount > 0)
        {
            --this._potCount;
            return true;
        }else{
            return false;
        }
    }
}
