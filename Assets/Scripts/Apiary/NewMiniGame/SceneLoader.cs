using UnityEngine.SceneManagement;

public class SceneLoader 
{
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("ScoreBoardTest");
    }

    public static void LoadGameplayScene()
    {
        SceneManager.LoadScene("Apiary");
    }
}
