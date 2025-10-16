using UnityEngine;
using TMPro;

public class BallCheck : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;   

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI restartText;

    Rigidbody2D rb;

    private Vector2 rbv;

    void Start(){
       UpdateUI();
       rb = GetComponent<Rigidbody2D>();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        string name = other.name.ToLower(); 

        if (name.Contains("heart"))
        {
            score += 10;
            rb.linearVelocity *= 5f;
        }
        else if (name.Contains("liver"))
        {
            score += 5;
        }
        else if (name.Contains("cuts"))
        {
            score -= 3;
        }
        else if (name.Contains("gut"))
        {
            rbv = rb.linearVelocity;
            rb.linearVelocity *= 0.2f;

        }
        else if (name.Contains("losecheck"))
        {
            lives -= 1;
            rbv = rb.linearVelocity;
            rb.linearVelocity *= 0.2f;


            if (lives <= 0)
            {
                lives = 0;
            }
        }

           UpdateUI();
    }

    void OnTriggerExit2D(Collider2D other){
         string name = other.name.ToLower(); 
        if (name.Contains("losecheck")){

            transform.position = new Vector3(3f, -3f, transform.position.z);
        }

        else if (name.Contains("gut"))
        {
            
            rb.linearVelocity /= 0.5f; 

        }

    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = score.ToString();

        if (livesText) livesText.text = lives.ToString();

        if (lives <= 0){
            restartText.text = "Press R to Start";
        }
        else{
           restartText.text = "  ";

        }
    }

    void Update(){
        if(lives <= 0){
            if (Input.GetKeyDown (KeyCode.R)){
            
                score = 0;
                lives = 3;
                UpdateUI();
            }
        }
    }
}
