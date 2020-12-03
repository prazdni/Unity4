using UnityEngine;


public class LemonMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    
    private Vector3 _direction;
    private bool _reachedFloor;

    #endregion


    #region Properties

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    public float Jump
    {
        get => _jump;
        set => _jump = value;
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _reachedFloor = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _reachedFloor = true;
        }
        
    }

    private void FixedUpdate()
    {

        WalkRealization();

        JumpRealization();

    }

    #endregion


    #region Methods

    private void WalkRealization()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _direction.Normalize();

        if (_direction.magnitude != 0)
        {
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0f);

            transform.position += _direction * _speed * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(desiredForward);

        }
    }
    private void JumpRealization()
    {
        if (Input.GetKey(KeyCode.Space) && _reachedFloor)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * _jump * Input.GetAxis("Jump");
            _reachedFloor = false;
        }
    }

    public bool IsSpeed()
    {
        bool haspseed = false;
        if (_reachedFloor && _direction.sqrMagnitude > 0)
        {
            haspseed = true;
        }
        return haspseed;
    }

    #endregion
}
