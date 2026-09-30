using UnityEngine;
using UnityEngine.InputSystem;

public class CubeThrower : MonoBehaviour
{
    [SerializeField] private InputActionReference throwAction;
    [SerializeField] private float UpForceRange;
    [SerializeField] private float sideForceRange;
    [SerializeField] private float rotationRange;
    private Rigidbody rb;

    private bool inProcess;
    public bool InProcess
    {
        get { return inProcess; }
        set { inProcess = value;}
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        throwAction.action.started += ThrowCube;
    }    

    private void Update()
    {

    }

    private void ThrowCube(InputAction.CallbackContext obj)
    {
        //if (!inProcess)
        //{
            var dir = new Vector3(
                Random.Range(-sideForceRange, sideForceRange),
                Random.Range(0, UpForceRange),
                Random.Range(-sideForceRange, sideForceRange));
            var rotation = Quaternion.Euler(
                Random.Range(-rotationRange, rotationRange),
                Random.Range(-rotationRange, rotationRange),
                Random.Range(-rotationRange, rotationRange));

            rb.AddForce(dir, ForceMode.Impulse);
            rb.MoveRotation(rotation);

            inProcess=true;
        //}
    }
}
