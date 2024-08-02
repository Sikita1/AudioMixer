using UnityEngine;
using UnityEngine.UI;

public class MusicPlayback : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _audioClip;

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play() =>
        _audio.PlayOneShot(_audioClip);
}
