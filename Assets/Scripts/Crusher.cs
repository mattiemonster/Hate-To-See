using System.Collections;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public Transform startPoint, endPoint;
    public bool moveToEnd = false, moveToStart = false;
    public float speed = 0.5f;
    public LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed);
            if (transform.position == endPoint.position)
            {
                moveToEnd = false;
            }
        }

        if (moveToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, 0.2f);
            if (transform.position == startPoint.position)
            {
                moveToStart = false;
            }
        }
    }

    public void Crush()
    {
        moveToEnd = true;
        GetComponent<AudioSource>().Play();
    }

    public void Return()
    {
        moveToStart = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            lm.Dead();
        }
    }
    
}
