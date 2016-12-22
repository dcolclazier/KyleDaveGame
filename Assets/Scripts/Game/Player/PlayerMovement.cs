using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


[RequireComponent(typeof(PolyNavAgent))]
public class PlayerMovement : NetworkBehaviour {
    public float Speed = 5.0f;
    public float Jump = 5f;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public Transform Target;

    public Rigidbody2D Rigidbody { get; private set; }
    public PolyNavAgent NavAgent { get; private set; }

    public void Awake() {
        Rigidbody = GetComponent<Rigidbody2D>();
        NavAgent = GetComponent<PolyNavAgent>();
    }

    public void SetDefaults() {
        //Stop();
        
       
    }
   
    private void Update() {
        if (!isLocalPlayer) return;

        //_currentHorizInput = Input.GetAxis("Horizontal");
        //_isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);

        //if (Input.GetKeyDown(KeyCode.E)) {
        //    var player = GameManager.Instance.GetPlayer(gameObject);
        //    player.Kill(2);
        //    player.SpawnPoint = player.gameObject.transform;
        //}
        
        //if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
        //    Rigidbody.AddForce(Vector2.up * Jump);
        //}
    }
   
    private void FixedUpdate() {
        if(!isLocalPlayer) return;

        Move();
    }

    public void Move()
    {
        //Rigidbody.velocity = new Vector2(_currentHorizInput * Speed, Rigidbody.velocity.y);
        if (Input.GetMouseButton(0)) NavAgent.SetDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    //public void Stop() {
    //    if(Rigidbody != null) Rigidbody.velocity = Vector2.zero;
    //}
}