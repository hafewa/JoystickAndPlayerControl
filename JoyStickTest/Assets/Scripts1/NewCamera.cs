using UnityEngine;
using System.Collections;

public class NewCamera : MonoBehaviour
{

    public GameObject cameraFather;
    public Transform target;
    public float rotatespeed;
    public float scalespeed;
    public float min;
    public float max;
    public Transform obj;
    public float cameraSpeed;

    private bool isLock = false;
    private Vector3 fCurrentRotation;
    private float currentSacale;
    private Vector3 currentRotation;
    private Vector3 lastMousePosition;
    // Use this for initialization
    void Start()
    {
        fCurrentRotation = cameraFather.transform.eulerAngles;
        currentRotation = transform.eulerAngles;
        lastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj != null && Input.GetKeyDown(KeyCode.Space) && isLock == false)
        {
            isLock = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            isLock = false;
        }
        if (isLock)
        {
            cameraFather.transform.position = obj.position;
        }
        else if (!Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x <= Screen.width && Input.mousePosition.x >= Screen.width - 60)
            {
                cameraFather.transform.Translate(new Vector3(1, 0, 0) * cameraSpeed * Time.deltaTime);
            }
            else if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= 60)
            {
                cameraFather.transform.Translate(new Vector3(1, 0, 0) * -cameraSpeed * Time.deltaTime);
            }
            if (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 60)
            {
                cameraFather.transform.Translate(new Vector3(0, 0, 1) * -cameraSpeed * Time.deltaTime);
            }
            else if (Input.mousePosition.y >= Screen.height - 60 && Input.mousePosition.y <= Screen.height)
            {
                cameraFather.transform.Translate(new Vector3(0, 0, 1) * cameraSpeed * Time.deltaTime);
            }
        }


        currentSacale = 0;
        //transform.LookAt (camerachild.position);
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            fCurrentRotation.y += mouseDelta.x * rotatespeed * Time.deltaTime;
            currentRotation.x += mouseDelta.y * rotatespeed * Time.deltaTime;
            currentRotation.y += mouseDelta.x * rotatespeed * Time.deltaTime;
        }
        currentSacale = Input.mouseScrollDelta.y * scalespeed * Time.deltaTime;
        if (currentSacale != 0)
            currentSacale = Mathf.Clamp(currentSacale, min, max);
        Debug.Log(currentSacale);
        transform.position = target.position;
        cameraFather.transform.eulerAngles = fCurrentRotation;
        transform.eulerAngles = currentRotation;
        transform.Translate(new Vector3(0, 0, currentSacale));
    }
}