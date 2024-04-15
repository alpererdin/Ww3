using UnityEngine;
using UnityEngine.EventSystems;

public class LeftBtnT : MonoBehaviour,
    IPointerDownHandler,IUpdateSelectedHandler,IPointerUpHandler
{
    public float currentZ;
    
    public bool isPressed = false;
    public float minZ = -20f;
    public float sensitivity = 5f;
    public Camera _main;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
   
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            MoveZ();
        }
    }
    private void MoveZ()
    {
        float currentZ = _main.transform.position.z;
        
        if (currentZ > minZ)
        { 
            currentZ -= sensitivity * Time.deltaTime;
            _main.transform.position = new Vector3(_main.transform.position.x, _main.transform.position.y, currentZ);
        }
    }
}