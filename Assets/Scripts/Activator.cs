using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    public bool createMode;
    public GameObject node;
    GameManager gameManager;

    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color oldColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObj = GameObject.Find("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
        oldColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (createMode)
            {
                Instantiate(node, transform.position, Quaternion.identity);
            }
            else
            {
                StartCoroutine(Pressed());

                if (active)
                {
                    note.GetComponent<Note>().SetAvailable(false);
                    Destroy(note);
                    AddScore();
                    gameManager.AddStreak();
                    active = false;
                    note = null;
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        active = true;
        if (other.gameObject.tag == "Note")
        {
            // Destroy(other.gameObject);
            note = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            Note note = other.gameObject.GetComponent<Note>();
            if (note.isAvailable)
            {
                gameManager.ResetStreak();
            }
        }
        active = false;
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gameManager.GetScore());
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);

        yield return new WaitForSeconds(0.05f);
        sr.color = oldColor;
    }
}
