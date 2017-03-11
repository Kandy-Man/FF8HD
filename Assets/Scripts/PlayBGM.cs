using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField]
    IntroloopAudio BGM;

    void Start()
    {
        IntroloopPlayer.Instance.Play(BGM);
    }
}