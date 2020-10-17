using UnityEngine;

public class Human : MonoBehaviour
{
    public float PlayerAxis
    {
        get { return _playerAxis; }
        set { _playerAxis = value; }
    }
    public bool PlayerGrounded { get; set; }
    public bool PlayerJumping { get; set; }
    public bool PlayerRunning { get; set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    
    private float _playerAxis;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}