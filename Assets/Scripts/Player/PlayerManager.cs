using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject aimTarget = null;
    
    private float _movementVelocity;
    private float _rotationSensitivity = 2f;
    private float _jumpVelocity = 0.5f;
    private float _boostVelocity = 1f;

    private AcManager _playerAcManager;
    private AssembleManager _assembleManager;
    
    private Transform _playerTransform;
    private Rigidbody _rigidbody;
    private Vector3 _movementTarget = Vector3.zero;

    void Start()
    {
        _playerTransform = this.transform;
        _rigidbody = GetComponent<Rigidbody>();
        _assembleManager = AssembleManager.GetInstance();
        _playerAcManager = GetComponent<AcManager>();

        _playerAcManager.SetArmorPoint(_assembleManager.GetAssembledArmorPoint());
        _movementVelocity = _assembleManager.GetAssembledMovementVelocity();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var currentPosition = _playerTransform.position;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var horizontalVelocity = _movementVelocity * Mathf.Sign(horizontalInput);
        var verticalVelocity = _movementVelocity * Mathf.Sign(verticalInput);

        if (horizontalInput < 0 || horizontalInput > 0)
        {
            _movementTarget += _playerTransform.right * horizontalVelocity;
        }

        if (verticalInput < 0 || verticalInput > 0)
        {
            _movementTarget += _playerTransform.forward * verticalVelocity;
        }

        _movementTarget.y = currentPosition.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(0, _jumpVelocity, 0, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(0, _boostVelocity, 0, ForceMode.Force);
        }

        var mouseX = Input.GetAxis("Mouse X") * _rotationSensitivity;
        var mouseY = Input.GetAxis("Mouse Y") * _rotationSensitivity * -1;
        
        _playerTransform.Rotate(mouseY, mouseX, 0);
        // なぜかZ回転するから応急処置
        var euler = _playerTransform.localEulerAngles;
        euler.z = 0;
        _playerTransform.localEulerAngles = euler;

        _playerTransform.position = Vector3.Lerp(currentPosition, _movementTarget, 0.4f);
    }

    public GameObject GetAimTarget() => aimTarget;
}
