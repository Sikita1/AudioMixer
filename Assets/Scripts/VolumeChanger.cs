using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private MusicMuter _musicMuter;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _name;

    private float _maximumSliderValue = 20f;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
        _musicMuter.Mute += AdjustVolume;
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
        _musicMuter.Mute -= AdjustVolume;
    }

    private void ChangeVolume(float value)
    {
        if (_musicMuter.IsButtonPressed)
            _mixerGroup.audioMixer.SetFloat(_name, Mathf.Log10(value) * _maximumSliderValue);
    }

    private void AdjustVolume()
    {
        if (_musicMuter.IsButtonPressed)
            ChangeVolume(_slider.value);
    }
}
