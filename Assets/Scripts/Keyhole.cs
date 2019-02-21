using UnityEngine;

public class Keyhole : MonoBehaviour
{
    public LevelManager lm;

    void Start()
    {
        GetComponent<Animator>().Play("KeyholeAnim");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (lm.hasKey)
            {
                GetComponent<Animator>().Play("KeyholeDisappear");
                GetComponent<AudioSource>().Play();
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(gameObject, 1f);
            }
        }
    }
}
