using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class goTennis : EventTrigger
{

    public override void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene("Tennis", LoadSceneMode.Single);
    }
}
