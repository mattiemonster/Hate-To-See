using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public string restartScene = "Intro";
    public GameObject heart;

    void Start()
    {
        heart.GetComponent<Animator>().Play("HeartAppear");
        heart.GetComponent<Animator>().Play("HeartAnim");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighestLevel");
            SceneManager.LoadScene(restartScene);
        }
    }
}
