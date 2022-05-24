using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void RestartPrecedLevel()
    {
        CustomSceneManager.Respawn();
    }
}