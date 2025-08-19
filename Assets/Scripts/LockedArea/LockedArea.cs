using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LockedArea : MonoBehaviour
{
    [SerializeField] private GameObject talkCanvas;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI talkText;
    [SerializeField] private string playerName;
    [SerializeField, TextArea(5, 10)]
    private string talk;

    public UnityEvent Action;

    private void Awake()
    {
        talkCanvas.SetActive(false);
        playerNameText.text = playerName;
        talkText.text = talk;
    }

    private void OnCollisionEnter(Collision collision)
    {
        talkCanvas.SetActive(true);
        Action.Invoke();
    }
    private void OnCollisionExit(Collision collision)
    {
        talkCanvas.SetActive(false);
    }
}
