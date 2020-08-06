using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public int boundary = 50;
    public int speed  = 20;

    private int theScreenWidth;
    private int theScreenHeight;
    private float startX;
    private float startY;
    private float endX;
    private float endY;

 
    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
        startX = transform.position.x;
        startY = transform.position.y;
        endX = startX + 38;
        endY = startY + 46;
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        if (Input.mousePosition.x > theScreenWidth - boundary)
        {
            cameraPosition.x = Mathf.Min(endX, cameraPosition.x + (speed * Time.deltaTime));
        }

        if (Input.mousePosition.x < 0 + boundary)
        {
            cameraPosition.x = Mathf.Max(startX, cameraPosition.x - (speed * Time.deltaTime));
        }

        if (Input.mousePosition.y > theScreenHeight - boundary)
        {
            cameraPosition.y = Mathf.Min(endY, cameraPosition.y + (speed * Time.deltaTime));
        }

        if (Input.mousePosition.y < 0 + boundary)
        {
            cameraPosition.y = Mathf.Max(startY, cameraPosition.y - (speed * Time.deltaTime));
        }

        transform.position = cameraPosition;
    }
}
