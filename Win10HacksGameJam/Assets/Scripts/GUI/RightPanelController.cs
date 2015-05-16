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
    [SerializeField]
    private Text _cashCounter = null;
    [SerializeField]
    private UpgradeManager upgradeManager = null;

    [Header("Parameters")]
    [Space(10)]
    public int _initialPotCount = 5;
    public float _potProgresMultiplier = 0.002f;
    
    private int _potCount = 0;
    private float _currentPotProgres = 0.0f;

    [SerializeField]
    private AnimationActivator messageSpinWheel = null;

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

        GameManager.Instance.OnReset += ResetGUI;
    }

    void Update()
    {
        if (!GameManager.Instance.IsPaused)
        {
            ProcesPotCreation();
            ProcesPotIndicator();
        }
    }

    void ProcesPotCreation()
    {
        this._currentPotProgres += this._wheelController.CurrentSpeed * this._potProgresMultiplier * Time.deltaTime;
        if (this._potCount < this.upgradeManager.MaxPotCount)
        {
            if (this._currentPotProgres > 1.0f)
            {
                this._currentPotProgres -= 1.0f;
                this._potCount += 1;
            }
        }else{
            this._currentPotProgres = Mathf.Clamp(this._currentPotProgres, 0.0f, 1.0f);
        }
    }
    public void ProcesPotIndicator()
    {
        this._potImage.fillAmount = this._currentPotProgres;
        this._potCouter.text = "x " + this._potCount + "/" + this.upgradeManager.MaxPotCount;
        this._cashCounter.text = "x " + GameManager.Instance.GetCash().ToString();
        
    }

    public void ResetGUI()
    {
        this._currentPotProgres = 0.0f;
        this._potCount = this._initialPotCount;
        this._wheelController.ResetWheelController();
    }

    public bool GetPotToThrow()
    {
        if(this._potCount > 0)
        {
            --this._potCount;
            return true;
        }else{
            DisplayMessageSpinWheel();
            return false;
        }
    }

    public void DisplayMessageSpinWheel()
    {
        if(this.messageSpinWheel != null)
        {
            this.messageSpinWheel.PlayMessageAnim();
        }
    }
}
