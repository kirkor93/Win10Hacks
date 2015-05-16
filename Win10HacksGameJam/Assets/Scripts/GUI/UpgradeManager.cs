using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour 
{
    private const int maxUpgradeLevel = 3;

    [SerializeField]
    private RightPanelController rightPanelController = null;

    [SerializeField]
    private Button buttonMaxPotCount = null;
    [SerializeField]
    private Text textMaxPotCount = null;
    [SerializeField]
    private Button buttonMaxStoneSpeed = null;
    [SerializeField]
    private Text textMaxStoneSpeed = null;

    private int maxPotCountInitialValue = 10;
    private int maxPotCountStep = 5;
    private int maxPotCountStepCost = 50;
    private int maxPotCountLevel = 0;

    private float maxStoneSpeedInitialValue = 560;
    private float maxStoneSpeedStep = 15;
    private int maxStoneSpeedStepCost = 50;
    private int maxStoneSpeedLevel = 0;

    public void Reset()
    {
        this.maxPotCountLevel = 0;
        this.maxStoneSpeedLevel = 0;
    }

    public int MaxPotCount
    {
        get
        {
            return this.maxPotCountInitialValue + this.maxPotCountLevel * this.maxPotCountStep;
        }
    }

    public float MaxStoneSpeed
    {
        get
        {
            return this.maxStoneSpeedInitialValue + this.maxStoneSpeedLevel * this.maxStoneSpeedStep;
        }
    }

    public void OnEnable()
    {
        UpdateUpgrades();
    }

    public void UpdateUpgrades()
    {
        int playerCash = GameManager.Instance.GetCash();
        if (this.maxPotCountLevel <= maxUpgradeLevel)
        {
            if (playerCash < this.maxPotCountStepCost)
            {
                this.buttonMaxPotCount.gameObject.SetActive(false);
                this.textMaxPotCount.gameObject.SetActive(true);
                this.textMaxPotCount.text = "Not enough cash...";
            }
            else
            {
                this.buttonMaxPotCount.gameObject.SetActive(true);
                this.textMaxPotCount.gameObject.SetActive(false);
            }
        }
        else
        {
            this.buttonMaxPotCount.gameObject.SetActive(false);
            this.textMaxPotCount.gameObject.SetActive(true);
            this.textMaxPotCount.text = "This upgrade is already at max level...";
        }
        if (this.maxStoneSpeedLevel <= maxUpgradeLevel)
        {
            if (playerCash < this.maxStoneSpeedStepCost)
            {
                this.buttonMaxStoneSpeed.gameObject.SetActive(false);
                this.textMaxStoneSpeed.gameObject.SetActive(true);
                this.textMaxStoneSpeed.text = "Not enough cash...";
            }
            else
            {
                this.buttonMaxStoneSpeed.gameObject.SetActive(true);
                this.textMaxStoneSpeed.gameObject.SetActive(false);
            }
        }
        else
        {
            this.buttonMaxStoneSpeed.gameObject.SetActive(false);
            this.textMaxStoneSpeed.gameObject.SetActive(true);
            this.textMaxStoneSpeed.text = "This upgrade is already at max level...";
        }
    }

    public void BuyMaxPotCountUpgrade()
    {
        int tmp = GameManager.Instance.GetCash();
        tmp -= this.maxPotCountStepCost;
        GameManager.Instance.SetCash(tmp);
        this.maxPotCountLevel += 1;
        UpdateUpgrades();
        this.rightPanelController.ProcesPotIndicator();
    }
    public void BuyMaxStoneSpeedUpgrade()
    {
        int tmp = GameManager.Instance.GetCash();
        tmp -= this.maxStoneSpeedStepCost;
        GameManager.Instance.SetCash(tmp);
        this.maxStoneSpeedLevel += 1;
        UpdateUpgrades();
        this.rightPanelController.ProcesPotIndicator();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
