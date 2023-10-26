using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]float moveSpeed = 1f;
    
    [SerializeField]int hp = 100; 

    [SerializeField]Slider HpBar ;
    // Start is called before the first frame update

    [SerializeField]Text ScoreText;

    [SerializeField]Button rstBtn;

    int score = 0;
    float timer = 0f;

    void Start()
    {
        hp = 100;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.W))
        // {
        //     transform.Translate(0, moveSpeed*Time.deltaTime, 0);
        // }
        // if(Input.GetKey(KeyCode.S))
        // {
        //     transform.Translate(0, -moveSpeed*Time.deltaTime, 0);
        // }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
        }
        if (transform.position.y > 4.2f)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 173, 173, 255);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (transform.position.y < -7f)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            this.GetComponent<BoxCollider2D>().enabled = true;    
        }

        

        updateScore();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Floor")
        {
            Debug.Log("tag Floor Collision!");
            if(other.contacts[0].normal == new Vector2(0f,1f) && other.contacts[0].normal == new Vector2(0f,1f))
            {
                addHP(5);
            }
        }
            

        if(other.gameObject.tag == "Lava")
        {
            Debug.Log("tag Lava Collision!");
            if(other.contacts[0].normal == new Vector2(0f,1f) && other.contacts[0].normal == new Vector2(0f,1f))
            {
                addHP(-10);
                other.gameObject.GetComponent<AudioSource>().Play();
                if(hp <= 0)
                {
                    dead();
                }
            }
            
        }
            
        if(other.gameObject.tag == "Ceil")
        {
            Debug.Log("tag Ceil Collision!");
                
        }
            
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "DeathZone")
        {
            Debug.Log("GameOver!");
            addHP(-100);
            if(hp <= 0)
            {
                dead();
            }
        }
            
    }

    void addHP(int val)
    {
        hp += val;
        hp = (hp > 100) ? 100 : (hp < 0) ? 0 : hp;
        HpBar.value = hp;
    }

    void updateScore()
    {
        timer += Time.deltaTime;
        score = (int) timer;
        ScoreText.text = $"分數: {score}";
    }

    void dead()
    {   
        Time.timeScale = 0;
        this.gameObject.GetComponent<AudioSource>().Play();
        rstBtn.gameObject.SetActive(true);
    }

    public void newGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
