using UnityEngine;

public class ClickOnEnvironment : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private LayerMask layer;
    void Start()
    {
        _camera = Camera.main;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,1000f,layer ))
            {
                GenerateExplosion(hit.point);
                Debug.Log("gen explosion  " + hit.point);
            }
           

        }

    }

     void GenerateExplosion(Vector3 point)
    {
        Instantiate(explosion, point, new Quaternion());
       
    }
}
