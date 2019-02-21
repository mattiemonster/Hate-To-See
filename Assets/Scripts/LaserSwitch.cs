using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public Laser laser;
    public bool triggered;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Animator>().StopPlayback();
            GetComponent<Animator>().Play("SwitchOn");
            GetComponent<AudioSource>().Play();
            laser.Disable();
        }
    }
}
