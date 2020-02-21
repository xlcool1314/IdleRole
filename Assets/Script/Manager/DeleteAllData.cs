using UnityEngine;
using System.Collections;
using UnityEditor;

public class JarodDeletePlayerPrefs
{

    [MenuItem("Assets/PlayerPrefs_DeleteAll")]
    static void PlayerPrefsDeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("DeleteAll finish!");
    }
}
