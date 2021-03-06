﻿using System;
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

    public string targetLevel;

    public void StartLevel()
    {
        if(GameManager.Instance.tutorial)
        {
            GameManager.Instance.tutorial = false;
            LoadLevel("tuto_1");
        } else
        {
            LoadLevel("level_0");
        }
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