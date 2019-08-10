using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 20f;

    public float scrollSpeed;

    public float minY = 50f;
    public float maxY = 80f;
    private float minX = -10f;
    private float maxX = 40f;
    private float minZ = -50f;
    private float maxZ = 30f;
    private bool DoMovement = true;


    // Update is called once per frame
    void Update()
    {
      
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("n"))
            DoMovement = !DoMovement;

        if (!DoMovement)
            return;

        if (Input.GetKey("a") || Input.mousePosition.x <=  panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
       // pos.x = Mathf.Clamp(pos.x, minX, maxX);
       // pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;

    }
}
