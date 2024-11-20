using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 4; 
    public int jump = 5;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(inputX * speed, rb.linearVelocity.y);
        
        print(tauchinGround());
        if (Input.GetKeyDown(KeyCode.Space) && tauchinGround() == true){
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    bool tauchinGround(){

        RaycastHit2D touch = Physics2D.Raycast(transform.position, Vector2.down, 0.2f); //lanzamo un rallo hacia abajo para er si estamos tocando el juego
        if(touch.collider == null){
            return false;  // no toa el suelo
        }else{
            return true; // estamos tocando el suelo 
        }
    }
}
