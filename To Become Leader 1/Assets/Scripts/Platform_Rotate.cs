using UnityEngine;

public class Platform_Rotate : MonoBehaviour
{
    [SerializeField] Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        //using Vector3, in relation to itself
        transform.Rotate(rotation * Time.deltaTime, Space.Self);
    }
}
