using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBeam : MonoBehaviour
{
    public LevelManager lm;

    void Start()
    {
        lm = GameObject.Find("Manager").GetComponent<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            lm.Dead();
        }
    }
}
