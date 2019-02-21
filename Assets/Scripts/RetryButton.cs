using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public Sprite selected, unselected;
    public bool isSelected = false;
    public SpriteRenderer sr;
    public AudioClip clickSound;

    public string levelScenePrefix;

    void OnMouseEnter()
    {
        gameObject.GetComponent<AudioSource>().Play();
        sr.sprite = selected;
    }

    void OnMouseExit()
    {
        sr.sprite = unselected;
    }

    void OnMouseDown()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickSound;
        audio.Play();

        if (PlayerPrefs.HasKey("HighestLevel"))
            SceneManager.LoadScene(levelScenePrefix + PlayerPrefs.GetInt("HighestLevel").ToString());
        else
            SceneManager.LoadScene(levelScenePrefix + "1");
    }
}
