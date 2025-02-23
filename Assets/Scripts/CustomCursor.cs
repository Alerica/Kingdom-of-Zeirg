using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePoistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        transform.position = mousePoistion; 
    }
}
