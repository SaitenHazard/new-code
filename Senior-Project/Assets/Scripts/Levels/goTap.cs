using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class goTap : EventTrigger
{

    public override void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene("Tap", LoadSceneMode.Single);
    }
}
