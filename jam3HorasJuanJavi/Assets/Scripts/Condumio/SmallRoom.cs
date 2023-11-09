using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRoom : MonoBehaviour
{
    public Transform mapPosition;
    public float offsetMap;
    public GameObject realWorldRoom;
    public Material matCurrent;

    private Vector3 originalPosition;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Start()
    {
        originalPosition = transform.position;
    }


    private void Update()
    {
        IfOutsideMapReset();
    }

    public void IfOutsideMapReset()
    {
        if ((transform.position.x - mapPosition.position.x) < offsetMap)
        {
            transform.position = originalPosition;
        }

        if ((transform.position.z - mapPosition.position.z) < offsetMap)
        {
            transform.position = originalPosition;
        }
    }

    private Vector3 screenPoint;
    private Vector3 offset;
    void OnMouseDown()
    {
        if (rend.material != matCurrent)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        
        if (rend.material != matCurrent)
        {
            Debug.Log("asdasd");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, transform.position.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
}
