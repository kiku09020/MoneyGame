using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

// AudioFile‚ª’Ç‰Á‚³‚ê‚é“x‚ÉŒÄ‚Î‚ê‚é
public class AudioFileChecker : AssetPostprocessor {

    const string FOLDER_PATH = "Assets/Resources/Audio/";

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPath)
    {
        if (importedAssets.Length == 0 && deletedAssets.Length == 0 && movedAssets.Length == 0 && movedFromAssetPath.Length == 0)
            return;

        if (importedAssets.Concat(deletedAssets).Concat(movedAssets).Any(x => x.Contains(FOLDER_PATH))) {
            AudioFileNameCreator.Create();
        }
    }
}
