using UnityEngine;
using System.Collections;

public class CrusherTrigger : MonoBehaviour
{
    public Crusher crusher;
    public float gracePeriod = 0.75f;
    public float crushingTime = 3f;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(Crush(gracePeriod));
        }
    }

    IEnumerator Crush(float secondsBeforeCrush)
    {
        yield return new WaitForSeconds(secondsBeforeCrush);
        crusher.Crush();
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(crushingTime);
        crusher.Return();
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
