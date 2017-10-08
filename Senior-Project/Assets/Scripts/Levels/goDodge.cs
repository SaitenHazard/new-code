using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class goDodge : EventTrigger
{

    public override void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene("Dodge", LoadSceneMode.Single);
    }
}
