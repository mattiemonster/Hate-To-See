using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Light[] lights;

    public Slider loveSlider;
    public float love = 100f;
    public bool hating = false;
    public GameObject hatingText;
    public float drainSpeed = 0.075f;
    public GameObject lightsObj;
    public GameObject fadeInImage;

    public bool hasKey = false;

    public GameObject outOfLoveImage;

    public GameObject keyUIObject;

    public int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (!hatingText)
            Debug.LogError("Hating text object not assigned");
        else
            hatingText.SetActive(false);
        
        if (!PlayerPrefs.HasKey("HighestLevel"))
            PlayerPrefs.SetInt("HighestLevel", levelNumber);
        else
        {
            if (!(PlayerPrefs.GetInt("HighestLevel") >= levelNumber))
                PlayerPrefs.SetInt("HighestLevel", levelNumber);
        }
        
        lights = lightsObj.GetComponentsInChildren<Light>();

        SetLights(false);

        fadeInImage.SetActive(true);

        loveSlider.maxValue = love;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Quit outright for now
        }

        if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.LeftShift))
        {
            hating = true;
            SetLights(true);
            hatingText.SetActive(true);
        }
        else
        {
            hating = false;
            SetLights(false);
            hatingText.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (hating)
        {
            love -= drainSpeed;
            loveSlider.value = love;
        }

        if (love <= 0f)
        {
            Debug.Log("Out of love.");
            EndGame();
        }
    }

    void SetLights(bool value)
    {
        foreach (Light light in lights)
            light.enabled = value;
    }

    public void EndGame()
    {
        // Switch scenes
        outOfLoveImage.SetActive(true);
        StartCoroutine(OutOfLove());
    }

    IEnumerator OutOfLove()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("OutOfLove");
    }

    public void Dead()
    {
        outOfLoveImage.SetActive(true);
        StartCoroutine(DeadAnim());
    }

    IEnumerator DeadAnim()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ObtainKey()
    {
        hasKey = true;
        keyUIObject.SetActive(true);
        keyUIObject.GetComponent<Animator>().Play("KeyUIAppear");
    }
}
