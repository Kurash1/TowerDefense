using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float CameraSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * CameraSpeed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * CameraSpeed;

        transform.Translate(new Vector3(x,y), Space.Self);
    }
}
