/* 
/// Copyright (c) 2015 Sirawat Pitaksarit, Exceed7 Experiments LP 
/// http://www.exceed7.com/introloop
*/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.IO;

public class IntroloopContextMenu : MonoBehaviour {
	
	[MenuItem ("Assets/Introloop/Create IntroloopAudio")]
	static void CreatePlayingScript()
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        ChangeAudioImportSettings(path);
		if(path == "")
		{
			path = "Assets";
		}
		else if(Path.GetExtension(path) != "")
		{
			path = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(Selection.activeObject));
		}
        CreateIntroloopAudioAsset(path,(AudioClip)Selection.activeObject);
	}

    static void ChangeAudioImportSettings(string path)
    {
        AudioImporter imp = AssetImporter.GetAtPath(path) as AudioImporter;
        imp.loadInBackground = true;
        imp.preloadAudioData = false;
        AudioImporterSampleSettings settings = imp.defaultSampleSettings;
        settings.compressionFormat = AudioCompressionFormat.Vorbis;
        imp.defaultSampleSettings = settings;
        imp.SaveAndReimport();
    }

	[MenuItem ("Assets/Introloop/Create IntroloopAudio",true)]
    static bool CreatePlayingScriptValidation()
    {
        return Selection.activeObject.GetType() == typeof(AudioClip);
    }
	
	public static T CreateAsset<T>() where T : ScriptableObject
	{
		return CreateAsset<T>("New " + typeof(T).ToString());
	}
	
	public static T CreateAsset<T>(string fileName) where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T>();
 
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if(path == "")
		{
			path = "Assets";
		}
		else if(Path.GetExtension(path) != "")
		{
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}
 
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + fileName + ".asset");
 
		AssetDatabase.CreateAsset(asset, assetPathAndName);
 
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
		
		return asset;
	}
	
	public static IntroloopAudio CreateIntroloopAudioAsset(string fileName,AudioClip audioClip)
	{
		IntroloopAudio asset = ScriptableObject.CreateInstance<IntroloopAudio>();
		asset.audioClip = audioClip;
		asset.Volume = 1;

		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if(path == "")
		{
			path = "Assets";
		}
		else if(Path.GetExtension(path) != "")
		{
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}
 
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + fileName + ".asset");
 
		AssetDatabase.CreateAsset(asset, assetPathAndName);
 
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
		
		return asset;
	}
}
