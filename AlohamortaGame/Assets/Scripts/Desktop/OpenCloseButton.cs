using UnityEngine;

public class OpenCloseButton : MonoBehaviour
{
    public void OpenClose(GameObject openObject)
    {
        openObject.SetActive(!openObject.activeSelf);
    }
}
