using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class goShoot : EventTrigger
{

    public override void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene("Shoot", LoadSceneMode.Single);
    }
}
