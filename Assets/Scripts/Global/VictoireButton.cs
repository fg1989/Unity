using UnityEngine;
using UnityEngine.UI;

public class VictoireButton : MonoBehaviour
{
    public void NextLevel()
    {
        CustomSceneManager.GoNextLevel();
    }

    public void Start()
    {
        GetComponent<Button>().interactable = CustomSceneManager.CanGoNext();
    }
}