using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageTrigger : MonoBehaviour
{
    public Message message;
    public GameObject messageUI;
    public TextMeshProUGUI messageText;
    public bool triggered = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggered)
            return;

        if (col.gameObject.tag == "Player")
        {
            messageText.text = message.messageText;
            messageUI.GetComponent<Animator>().Play("MsgBoxAnim");
            messageUI.GetComponent<Animator>().Play("MsgBoxAppear");
            StartCoroutine(CloseMessage(message.timeToStay));
            gameObject.GetComponent<AudioSource>().Play(); // Play sound

            triggered = true;
        }
    }

    IEnumerator CloseMessage(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        messageUI.GetComponent<Animator>().Play("MsgBoxDisappear");
        Destroy(gameObject);
    }
}
