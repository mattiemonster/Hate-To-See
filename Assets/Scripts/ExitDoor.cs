using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public string nextLevel;

    public GameObject fadeOutImage;
    public bool playSound;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            fadeOutImage.SetActive(true);
            StartCoroutine(LoadScene());
            if (playSound)
                GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(nextLevel);
    }
}
