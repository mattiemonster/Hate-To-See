using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
    public string firstLevelName;
    public string levelPrefix;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerPrefs.HasKey("HighestLevel"))
            {
                SceneManager.LoadScene(levelPrefix + PlayerPrefs.GetInt("HighestLevel").ToString());
            } else
            {
                SceneManager.LoadSceneAsync(firstLevelName);
            }
        }
    }
}
