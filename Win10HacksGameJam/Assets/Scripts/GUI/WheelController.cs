using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelController : MonoBehaviour 
{
    [Space(10)]
    [Header("Object References")]
    [SerializeField]
    private Image _wheelImage = null;
    [SerializeField]
    private Slider _speedIndicator = null;
    [SerializeField]
    private Text _potCounter = null;

    [Header("Parameters")]
    [Space(10)]
    public float _maxSpeed = 720.0f;
    public float _minSpeed = 0.0f;
    public float _currentSpeed = 0.0f;
    public float _speedDrag = 45.0f;
    private float _direction = -1.0f;
    public float _spinTheWheelValue = 45.0f;

    private AudioSource audioSource;

    public float CurrentSpeed
    {
        get
        {
            return this._currentSpeed;
        }
    }

    public void ResetWheelController()
    {
        this._currentSpeed = this._minSpeed;
    }

    void Start()
    {
        if (this._wheelImage == null)
        {
            Debug.LogError("Missing reference to wheel image.");
        }
        if (this._speedIndicator == null)
        {
            Debug.LogError("Missing reference to speed indicator.");
        }
        if (this._potCounter == null)
        {
            Debug.LogError("Missing reference to pot counter.");
        }

        this.audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!GameManager.Instance.IsPaused)
        {
            ProcesWheel();
            UpdateLabels();
        }
    }

    private void ProcesWheel()
    {
        this._currentSpeed -= this._speedDrag * Time.deltaTime;
        this._currentSpeed = Mathf.Clamp(this._currentSpeed, this._minSpeed, this._maxSpeed);
        if(this._currentSpeed > 0.0f)
        {
            this.audioSource.volume = 1.0f;
        }
        else
        {
            this.audioSource.volume = 0.0f;
        }

        Quaternion quat = this._wheelImage.rectTransform.rotation;
        Vector3 rot = quat.eulerAngles;
        rot.z += this._currentSpeed * this._direction * Time.deltaTime;
        quat.eulerAngles = rot;
        this._wheelImage.rectTransform.rotation = quat;
    }

    public void UpdateLabels()
    {
        _speedIndicator.value = (this._currentSpeed - this._minSpeed) / (this._maxSpeed - this._minSpeed);
    }

    public void SpinTheWheel()
    {
        this._currentSpeed += this._spinTheWheelValue;
    }
}
