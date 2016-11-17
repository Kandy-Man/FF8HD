/* 
/// Copyright (c) 2015 Sirawat Pitaksarit, Exceed7 Experiments LP 
/// http://www.exceed7.com/introloop
*/

using UnityEngine;
using System.Collections;
using System;

public class IntroloopAudio : ScriptableObject
{
	
	[SerializeField, Range(0,1)]
	private float volume;

    [SerializeField]
    public AudioClip audioClip;
    [SerializeField,PositiveFloat]
    internal float introBoundary;
    [SerializeField,PositiveFloat]
    internal float loopingBoundary;
    [SerializeField]
    internal bool nonLooping;
    [SerializeField]
    internal bool loopWholeAudio;

    public float ClipLength
    {
        get{
            return audioClip.length;
        }
    }

	public float Volume {
		get {
			return this.volume;
		}
		set {
			this.volume = value;
		}
	}
	
    internal float IntroLength
    {
        get{
            return introBoundary;
        }
    }

    internal float LoopingLength
    {
        get{
            return loopingBoundary - introBoundary;
        }
    }
	
	internal void Unload()
	{
        audioClip.UnloadAudioData();
	}
}

