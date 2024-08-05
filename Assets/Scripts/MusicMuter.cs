using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicMuter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _name;

    private float _minValue = -80f;

    public event Action Mute;
    public bool IsButtonPressed { get; private set; }

    private void Awake()
    {
        IsButtonPressed = true;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Switch);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Switch);
    }

    private void Switch()
    {
        IsButtonPressed = !IsButtonPressed;

        if (IsButtonPressed == false)
            _mixerGroup.audioMixer.SetFloat(_name, _minValue);

        Mute?.Invoke();
    }
}
