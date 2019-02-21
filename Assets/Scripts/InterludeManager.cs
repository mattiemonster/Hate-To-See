using UnityEngine;
using UnityEngine.SceneManagement;

public class InterludeManager : MonoBehaviour
{
    public string returnLevel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(returnLevel);
        }
    }
}
