using UnityEngine;

public class PusherMove : MonoBehaviour

{
    public Rigidbody2D pusher;      
    public Rigidbody2D ball;        
    public float chargeTime = 1f;   
    public float pushDistance = 0.5f; 
    public float returnSpeed = 6f;  
    public float maxImpulse = 20f;   

    private Vector2 restPos;        
    private bool charging;
    private float t0;
    private bool releasing;
    private float targetY;          

    void Start()
    {
        restPos = pusher.position;         
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charging = true;
            releasing = false;
            t0 = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space) && charging)
        {
            charging = false;
            releasing = true;

            float held = Time.time - t0;
            float ratio = Mathf.Clamp01(held / chargeTime);

            
            ball.linearVelocity = new Vector2(ball.linearVelocity.x, Mathf.Max(ball.linearVelocity.y, ratio * maxImpulse));
        }
    }

    void FixedUpdate()
{
    if (charging)
    {

        float held = Mathf.Min(Time.time - t0, chargeTime);
        float ratio = held / chargeTime;          
        float y = restPos.y - ratio * pushDistance; 
        pusher.MovePosition(new Vector2(restPos.x, y));
    }
    else if (releasing)
    {

        Vector2 target = restPos;
        Vector2 next = Vector2.MoveTowards(pusher.position, target, returnSpeed * Time.fixedDeltaTime);
        pusher.MovePosition(next);
        if (Vector2.Distance(next, restPos) < 0.001f)
            releasing = false;
    }
}

}


