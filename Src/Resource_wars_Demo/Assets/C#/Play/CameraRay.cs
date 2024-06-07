using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public static CameraRay Instance;
    public Camera Camera;
    public Ray ray ;
    public RaycastHit hit;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Camera = Camera.main;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ray = Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
        }
    }
    void Update()
    {
       
       
    }
}
