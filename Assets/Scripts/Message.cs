using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Message", menuName = "Game/Message", order = 1)]
public class Message : ScriptableObject
{
    public string messageText;
    public string sayer;
    public float timeToStay = 3f;
}
