using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject particle, beam;
    public float toggleTime = 3f;

    bool laserEnabled = false;
    BoxCollider2D bc;

    public bool toggles = true;

    void Start()
    {
        beam.GetComponent<Animator>().Play("LaserBeamAnim");
        bc = beam.GetComponent<BoxCollider2D>();
        if (toggles)
            InvokeRepeating("Toggle", 0, toggleTime);
    }

    void Toggle()
    {
        if (laserEnabled)
        {
            // Disable
            beam.GetComponent<Animator>().Play("LaserBeamDisable");
            particle.GetComponent<ParticleSystem>().Stop(false, ParticleSystemStopBehavior.StopEmitting);
            bc.enabled = false;
            laserEnabled = false;
        } else
        {
            // Enable
            beam.GetComponent<Animator>().Play("LaserBeamEnable");
            particle.GetComponent<ParticleSystem>().Play();
            bc.enabled = true;
            laserEnabled = true;
        }
    }

    public void Disable()
    {
        CancelInvoke("Toggle");
        beam.GetComponent<Animator>().Play("LaserBeamDisable");
        particle.GetComponent<ParticleSystem>().Stop(false, ParticleSystemStopBehavior.StopEmitting);
        bc.enabled = false;
        laserEnabled = false;
    }
}
