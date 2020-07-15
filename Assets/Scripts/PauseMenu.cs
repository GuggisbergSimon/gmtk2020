using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject remapPanel = null;
    [SerializeField] private GameObject winPanel = null;
    [SerializeField] private AudioClip[] chooseNoises = null;
    [SerializeField] private AudioClip chooseSpecialNoise = null;
    [SerializeField] private AudioClip winNoise = null;
    private AudioSource _source;
    
    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySoundChoose()
    {
        _source.PlayOneShot(chooseNoises[Random.Range(0,chooseNoises.Length)]);
    }

    public void PlaySoundChooseSpecial()
    {
        _source.PlayOneShot(chooseSpecialNoise);
    }

    public void ToggleRemap(bool toggle)
    {
        GameManager.Instance.Player.CanMove = !toggle;
        remapPanel.SetActive(toggle);
    }

    public void ToggleWin(bool toggle)
    {
        GameManager.Instance.Player.CanMove = !toggle;
        winPanel.SetActive(toggle);
        if (toggle)
        {
            _source.PlayOneShot(winNoise);
        }
    }
}
