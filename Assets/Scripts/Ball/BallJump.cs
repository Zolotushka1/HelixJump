using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private AudioClip _bounceSound;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = _bounceSound;
        
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude > _jumpForce)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _jumpForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GetComponent<AudioSource>().Play ();
        
        if (other.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
