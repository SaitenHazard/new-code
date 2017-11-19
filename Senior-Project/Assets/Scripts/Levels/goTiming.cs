using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class goTiming : EventTrigger
{

    public override void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene("Timing", LoadSceneMode.Single);
    }
}
