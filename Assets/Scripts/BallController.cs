using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float jumpForce;

    public Rigidbody2D rb;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    public int star;
    public Text scoreStarText;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        RandomColor();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            star++;
            scoreStarText.text = star.ToString();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag == "ColorChanger")
        {
            RandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }
    void RandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = colorBlue;
                break;

        }
    }
}
