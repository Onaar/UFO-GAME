using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 5f;
    public int counter;
    public Text scoreText;
    public Text winText;
    public int GoldNumber;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        counter = 0;
    }

    // Update is called once per tick of engine
    private void FixedUpdate()
    {
        //1. pobranie informacji o ruchu z klawiatury
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //2. skonstruowanie wektora ruchu na podstawie pkt.1
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //3. uzycie sily na obiekcie
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            counter++;
            UpdateScoreOnText();
        }
    }

    void UpdateScoreOnText()
    {
        scoreText.text = "Wynik: " + counter.ToString();
        if (counter == GoldNumber)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
