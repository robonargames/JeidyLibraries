using System.Collections;
using UnityEngine;


public class Billboard : MonoBehaviour
{    
    [SerializeField] Transform target;
    [SerializeField] float closeToCamera;    
    
    private Vector3 _offset;
    [SerializeField] float offsetY = 0.75f;
    private float _offsetRotZ;
    private Transform _cam;


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => Camera.main != null);

        _cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (_cam == null || target == null)
            return;


        _offset = (Vector3.up * offsetY);
        _offsetRotZ = Vector3.SignedAngle(-_cam.forward, Vector3.up, _cam.right);

        transform.LookAt(transform.position + _cam.forward);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.y, _offsetRotZ);
        transform.position = target.position + _offset - (_cam.forward * closeToCamera);
    }

}
