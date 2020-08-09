using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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
        endX = transform.position.x;
        startY = transform.position.y;
        startX = endX - 38;
        endY = startY + 46;
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
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

    public IEnumerator ScrollToPlayer(Transform playerTransform)
    {
        float targetX = Mathf.Clamp(playerTransform.position.x, startX, endX);
        float targetY = Mathf.Clamp(playerTransform.position.y, startY, endY);
        
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);
        float transitionTime;
        if(Vector3.Magnitude(startingPos + targetPosition) < 60)
        {
            transitionTime = 0.5f;
        }
        else
        {
            transitionTime = 1f;
        }
        while(t < transitionTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, targetPosition, t);
            yield return null;
        }
    }
}
