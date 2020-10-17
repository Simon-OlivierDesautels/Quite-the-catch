using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Human ParentClass;
    [SerializeField] private bool _debug;
    [SerializeField] private float _gizmosLength;
    [SerializeField] private Vector3 colliderOffset;
    [SerializeField] private LayerMask _groundMask;

    private void Start()
    {
        ParentClass = GetComponent<Human>();
    }

    private void Update()
    {
        GroundCollisionDetection();
    }

    private void GroundCollisionDetection()
    {
        ParentClass.PlayerGrounded = Physics2D.Raycast
            (transform.position + colliderOffset, Vector3.down, _gizmosLength, _groundMask);
    }
}