using UnityEngine.SceneManagement;

public static class CustomSceneManager
{
    static CustomSceneManager()
    {
        totalScene = SceneManager.sceneCountInBuildSettings;
    }

    public static void GoNextLevelMessage()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public static void GoNextLevel()
    {
        currentLevel++;
        SceneManager.LoadSceneAsync(currentLevel);
    }

    public static void GoDead()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public static void Respawn()
    {
        SceneManager.LoadSceneAsync(currentLevel);
    }

    public static bool CanGoNext()
    {
        return currentLevel + 1 < totalScene;
    }

    private static readonly int totalScene;
    private static int currentLevel = 1;
}