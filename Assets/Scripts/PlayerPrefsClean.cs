using UnityEngine;

public class PlayerPrefsClean
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoad()
    {
        PlayerPrefs.DeleteAll();
    }
}