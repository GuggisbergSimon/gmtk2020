using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip[] chooseNoises = null;
    [SerializeField] private AudioClip chooseSpecialNoise = null;
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void LoadLevel(string level)
    {
        GameManager.Instance.PlayMusic(true);
        GameManager.Instance.LoadLevel(level);
    }

    public void PlaySoundChoose()
    {
        _source.PlayOneShot(chooseNoises[Random.Range(0,chooseNoises.Length)]);
    }

    public void PlaySoundChooseSpecial()
    {
        _source.PlayOneShot(chooseSpecialNoise);
    }
}