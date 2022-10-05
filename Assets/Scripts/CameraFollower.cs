using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {

        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z - 15;
        transform.position = transformPosition;


    }
}
