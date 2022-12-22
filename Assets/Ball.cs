using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float jump = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;

    public void RandomColor()
    {
        int color = Random.Range(0, 4);
        switch (color)
        {
            case 0:
                currentColor = "Blue";
                sr.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //The council will decide your fate
        RandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            rb.velocity = Vector2.up * jump;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            rb.velocity = Vector2.right * jump;
        }
        else if (Input.GetMouseButtonDown(2))
        {
            rb.velocity = Vector2.left * jump;
        }
        if (rb.position.y < 0)
        {
            transform.position = new Vector2 (rb.position.x, 0.00001f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name != currentColor)
        {
            if (collision.name == "ColorChanger")
            {
                Destroy(collision.gameObject);
            } else if (collision.name == "EEEE")
            {
                rb.velocity = Vector2.up * Random.Range(10, 26);
            } else if (collision.name == "EEEEE")
            {
                rb.velocity = Vector2.left * Random.Range(15, 26);
            }
            else if (collision.name == "finish")
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
}
