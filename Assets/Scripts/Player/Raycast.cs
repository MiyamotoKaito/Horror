using UnityEngine;

public class Raycast : MonoBehaviour
{
    Vector3 origin = new Vector3(0, 0, 0);
    Vector3 direction = new Vector3(1, 0, 0);


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(origin, direction);
        Raycast hit;
    }
}
