using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public float rotationSpeed = 25f;
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private Vector3 meshCentre;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshCentre = GetComponent<MeshRenderer>().bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if(isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            float rotationX = delta.x * rotationSpeed * Time.deltaTime;
            float rotationY = delta.y * rotationSpeed * Time.deltaTime;

            transform.RotateAround(meshCentre, Vector3.up, -rotationX); //horizontal drag - Y-Axis
            transform.RotateAround(meshCentre, Vector3.right, rotationY);//vertical drag = X-Axis

            lastMousePosition = Input.mousePosition;
        
        }
    }
}
