using UnityEngine;

public class Key : MonoBehaviour
{
    public LevelManager lm;
    public GameObject keyPickupParticle;

    void Start()
    {
        GetComponent<Animator>().Play("KeyAnim");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            lm.ObtainKey();
            GetComponent<AudioSource>().Play();
            Destroy(Instantiate(keyPickupParticle, transform.position, Quaternion.identity), 2f);
            GetComponent<Animator>().Play("KeyDisappear");
            Destroy(GetComponent<EdgeCollider2D>());
            Destroy(gameObject, 2f);
        }
    }
}
