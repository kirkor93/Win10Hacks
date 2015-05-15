using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelController : MonoBehaviour 
{

    private float _maxSpeed = 720.0f;
    private float _minSpeed = 0.0f;
    private float _currentSpeed = 0.0f;
    private float _speedDrag = 15.0f;
    private float _direction = -1.0f;

    private float _spinTheWheelValue = 15.0f;

    [SerializeField]
    private Image _wheelImage = null;
    [SerializeField]
    private Slider _speedIndicator = null;
    [SerializeField]
    private Text _potCounter = null;

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
    }

    void Update()
    {
        ProcesWheel();
        UpdateLabels();
    }

    private void ProcesWheel()
    {
        this._currentSpeed -= this._speedDrag * Time.deltaTime;
        this._currentSpeed = Mathf.Clamp(this._currentSpeed, this._minSpeed, this._maxSpeed);

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
