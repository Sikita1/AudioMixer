using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _name;
    [SerializeField] private Button _button;

    private bool _isButtonPressed;
    private float _minValue = -80f;

    private float _value = 20f;

    private float _currentValue;

    private void OnEnable()
    {
        _button.onClick.AddListener(Mute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Mute);
    }

    private void Mute()
    {
        if (GetButtonPressed())
            AssignValue(_minValue);
        else
            AssignValue(_currentValue);
    }

    private bool GetButtonPressed() =>
        _isButtonPressed = !_isButtonPressed;

    public void ChangeVolume(float volume)
    {
        if (_isButtonPressed == false)
            AssignValue(Mathf.Log10(volume) * _value);
    }

    private void AssignValue(float value)
    {
        _mixerGroup.audioMixer.GetFloat(_name, out float currentValue);
        _mixerGroup.audioMixer.SetFloat(_name, value);

        _currentValue = currentValue;
    }
}
