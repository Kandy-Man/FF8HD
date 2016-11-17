/* 
/// Copyright (c) 2015 Sirawat Pitaksarit, Exceed7 Experiments LP 
/// http://www.exceed7.com/introloop
*/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class IntroloopPlayer : MonoBehaviour
{
	private IntroloopTrack[] twoTracks;
	private float[] towardsVolume;
	private bool[] willStop;
	private bool[] willPause;
	private float[] fadeLength;
    //Will change to 0 on first Play(), 0 is the first track.
	private int currentTrack = 1; 
    //This fade is inaudible, it helps removing loud pop/click when you stop song suddenly. (0 fade length)
	private const float popRemovalFadeTime = 0.055f; 

	private static IntroloopPlayer instance;
    internal IntroloopSettings introloopSettings;
	
    /// <summary>
    /// Singleton pattern point of access. Get the instance of IntroloopPlayer.
    /// </summary>
	public static IntroloopPlayer Instance {
		get {
			if(instance == null) {
				instance = (IntroloopPlayer)FindObjectOfType(typeof(IntroloopPlayer));
                if(instance == null)
                {
                    //Try loading a template prefab
                    GameObject templatePrefab = Resources.Load(IntroloopSettings.defaultTemplatePath) as GameObject;

                    GameObject introloopPlayer;
                    if(templatePrefab != null)
                    {
                        introloopPlayer = Instantiate(templatePrefab);
                        introloopPlayer.name = IntroloopSettings.defaultGameObjectName;
                    }
                    else
                    {
                        //Create a new one in hierarchy, and this one will persist throughout the game/scene too.
                        introloopPlayer = new GameObject(IntroloopSettings.defaultGameObjectName);
                        introloopPlayer.AddComponent<IntroloopPlayer>(); //This point Awake will be called
                    }

                    instance = introloopPlayer.GetComponent<IntroloopPlayer>();
                }
			}
			return instance;
		}
	}
		
	void Awake()
	{	
        //Check for duplicates in the scene
		UnityEngine.Object[] introloopPlayers = FindObjectsOfType(typeof(IntroloopPlayer));
		for(int i = 0; i < introloopPlayers.Length; i++) {
			if(introloopPlayers[i] != this) { //Not conform to singleton pattern
				//Self destruct!
				Destroy(gameObject);
			}
		}

        DontDestroyOnLoad(gameObject);

        introloopSettings = gameObject.GetComponent<IntroloopSettings>();
        if(introloopSettings == null)
        {
            introloopSettings = gameObject.AddComponent<IntroloopSettings>();
        }
		
		towardsVolume = new float[2];
		willStop = new bool[2];
		willPause = new bool[2];
		twoTracks = new IntroloopTrack[2];
		fadeLength = new float[2]{introloopSettings.defaultFadeLength,introloopSettings.defaultFadeLength};

        CreateImportantChilds();	
	}
	
	void CreateImportantChilds()
	{
        //These are all the components that make this plugin works. Basically 4 AudioSources with special control script
        //to juggle music file carefully, stop/pause/resume gracefully while retaining the Introloop function.

		Transform musicPlayerTransform = transform;
		GameObject musicTrack1 = new GameObject();
		musicTrack1.AddComponent<IntroloopTrack>();
		musicTrack1.name = "Music Track 1";
		musicTrack1.transform.parent = musicPlayerTransform;
		twoTracks[0] = musicTrack1.GetComponent<IntroloopTrack>();
        twoTracks[0].SetMixerGroup(introloopSettings.routeToMixerGroup);
		
		GameObject musicTrack2 = new GameObject();
		musicTrack2.AddComponent<IntroloopTrack>();
		musicTrack2.name = "Music Track 2";
		musicTrack2.transform.parent = musicPlayerTransform;
		twoTracks[1] = musicTrack2.GetComponent<IntroloopTrack>();
        twoTracks[1].SetMixerGroup(introloopSettings.routeToMixerGroup);
	}

	void Update()
	{
		FadeUpdate();
	}
	
	private void FadeUpdate()
	{
		//For two main tracks
		for(int i=0; i< 2; i++) {
			float towardsVolumeBgmVolumeApplied = towardsVolume[i];
			if(twoTracks[i].FadeVolume != towardsVolumeBgmVolumeApplied) { //Fade in/out
				if(fadeLength[i] == 0) {
					twoTracks[i].FadeVolume = towardsVolumeBgmVolumeApplied;
				} else {
					if(twoTracks[i].FadeVolume > towardsVolumeBgmVolumeApplied) {
						twoTracks[i].FadeVolume -= Time.deltaTime / fadeLength[i];
						if(twoTracks[i].FadeVolume <= towardsVolumeBgmVolumeApplied) {
							//Stop the fade
							twoTracks[i].FadeVolume = towardsVolumeBgmVolumeApplied;
						}
					} else {
						twoTracks[i].FadeVolume += Time.deltaTime / fadeLength[i];
						if(twoTracks[i].FadeVolume >= towardsVolumeBgmVolumeApplied) {
							//Stop the fade
							twoTracks[i].FadeVolume = towardsVolumeBgmVolumeApplied;
						}
					}
				}
				//Stop check
				if(willStop[i] && twoTracks[i].FadeVolume == 0) {
					willStop[i] = false;
					willPause[i] = false;
					twoTracks[i].Stop();
					UnloadTrack(i);
				}
				//Pause check
				if(willPause[i] && twoTracks[i].FadeVolume == 0) {
					willStop[i] = false;
					willPause[i] = false;
					twoTracks[i].Pause();
					//don't unload!
				}
			}
		}
	}
	
	private void UnloadTrack(int trackNumber)
	{
		//Have to check if other track is using the music or not?
		bool usingAndPlaying = ( twoTracks[(trackNumber+1)%2].IsPlaying &&
			twoTracks[trackNumber].Music == twoTracks[(trackNumber+1)%2].Music);
		bool aboutToPlay = (twoTracks[trackNumber].Music ==
			twoTracks[(trackNumber+1)%2].MusicAboutToPlay);
		
		if(!usingAndPlaying && !aboutToPlay)
		{
            //If not, it is now safe to unload it
			twoTracks[trackNumber].Unload();
		}
	}
	
	internal void ApplyVolumeSettingToAllTracks()
	{
		twoTracks[0].ApplyVolume();
		twoTracks[1].ApplyVolume();
	}

    /// <summary>
    /// Play the audio using settings specified in IntroloopAudio file's inspector area.
    /// </summary>
    /// <param name="audio"> An IntroloopAudio asset file to play.</param>
	public void Play(IntroloopAudio audio)
	{
		PlayFade(audio, 0);
	}
	
    /// <summary>
    /// Play the audio using settings specified in IntroloopAudio file's inspector area with fade-in 
    /// or cross fade (if other IntroloopAudio is playing now) default length specified in IntroloopSettings component
    /// that is attached to IntroloopPlayer.
    /// </summary>
    /// <param name="audio"> An IntroloopAudio asset file to play.</param>
	public void PlayFade(IntroloopAudio audio)
	{
		PlayFade(audio, introloopSettings.defaultFadeLength);
	}
	
    /// <summary>
    /// Play the audio using settings specified in IntroloopAudio file's inspector area with fade-in 
    /// or cross fade (if other IntroloopAudio is playing now) length specified by argument.
    /// </summary>
    /// <param name="audio"> An IntroloopAudio asset file to play.</param>
    /// <param name="fadeLengthSeconds"> Fade in/Cross fade length to use.</param>
	public void PlayFade(IntroloopAudio audio, float fadeLengthSeconds)
	{
		//Auto-crossfade old ones. If no fade length specified, a very very small fade will be used to avoid pops/clicks.
		StopFade(fadeLengthSeconds== 0 ? popRemovalFadeTime : fadeLengthSeconds); 
		
		int next = (currentTrack + 1) % 2;
		twoTracks[next].Play(audio,fadeLengthSeconds == 0 ? false : true);
		towardsVolume[next] = 1;
		fadeLength[next] = fadeLengthSeconds;
		
		currentTrack = next;
	}
	
    /// <summary>
    /// Stop the currently playing IntroloopAudio instantly, and unload the audio from memory.
    /// </summary>
	public void Stop()
	{
		StopFade(popRemovalFadeTime);
	}
	
    /// <summary>
    /// Stop the currently playing IntroloopAudio with fade out length specified by
    /// default length specified in IntroloopSettings component. Unload the audio from memory once
    /// the fade out finished.
    /// </summary>
	public void StopFade()
	{
		StopFade(introloopSettings.defaultFadeLength);
	}
	
    /// <summary>
    /// Stop the currently playing IntroloopAudio with fade out length specified by
    /// argument. Unload the audio from memory once the fade out finished.
    /// </summary>
    /// <param name="fadeLengthSeconds">Fade out length to use.</param>
	public void StopFade(float fadeLengthSeconds)
	{
		willStop[currentTrack] = true;
		willPause[currentTrack] = false;
		fadeLength[currentTrack] = fadeLengthSeconds;
		towardsVolume[currentTrack] = 0;
	}

    /// <summary>
    /// Stop the currently playing IntroloopAudio instantly without unloading,
    /// you will be able to use Resume() to continue later.
    /// </summary>
	public void Pause()
	{
		PauseFade(popRemovalFadeTime);
	}
	
    /// <summary>
    /// Stop the currently playing IntroloopAudio without unloading,
    /// with fade length specified by default length in IntroloopSettings component.
    /// You will be able to use Resume() to continue later.
    /// </summary>
	public void PauseFade()
	{
		PauseFade(introloopSettings.defaultFadeLength);
	}
	
    /// <summary>
    /// Stop the currently playing IntroloopAudio without unloading,
    /// with fade length specified by the argument.
    /// You will be able to use Resume() to continue later.
    /// </summary>
    /// <param name="fadeLengthSeconds">Fade out length to use.</param>
	public void PauseFade(float fadeLengthSeconds)
	{
        if(twoTracks[currentTrack].IsPausable())
        {
            willPause[currentTrack] = true;
            willStop[currentTrack] = false;
            fadeLength[currentTrack] = fadeLengthSeconds;
            towardsVolume[currentTrack] = 0;
        }
	}
	
    /// <summary>
    /// Resume playing of previously paused IntroloopAudio instantly.
    /// </summary>
	public void Resume()
	{
		ResumeFade(0);
	}
	
    /// <summary>
    /// Resume playing of previously paused IntroloopAudio with fade in length
    /// specified in IntroloopSettings component.
    /// </summary>
	public void ResumeFade()
	{
		ResumeFade(introloopSettings.defaultFadeLength);
	}
	
    /// <summary>
    /// Resume playing of previously paused IntroloopAudio with fade in length
    /// specified by argument.in IntroloopSettings component.
    /// </summary>
    /// <param name="fadeLengthSeconds">Fade out length to use.</param>
	public void ResumeFade(float fadeLengthSeconds)
	{
		if(twoTracks[currentTrack].Resume()) {
			//Resume success
			willStop[currentTrack] = false;
			willPause[currentTrack] = false;
			towardsVolume[currentTrack] = 1;
			fadeLength[currentTrack] = fadeLengthSeconds;	
		}
	}

    //These 3 functions is for debugging purpose.

    public float GetTime()
    {
        return twoTracks[currentTrack].PlayheadPositionSeconds;
    }
	
	public string[] GetDebugInformation1()
	{
		return twoTracks[0].DebugInformation;
	}

	public string[] GetDebugInformation2()
	{
		return twoTracks[1].DebugInformation;
	}
}
