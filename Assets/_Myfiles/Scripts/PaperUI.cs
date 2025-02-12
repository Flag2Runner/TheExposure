using System;
using TMPro;
using UnityEngine;

public class PaperUI : MonoBehaviour
{
    [SerializeField] LockController relatedLockController;
    [SerializeField] TextMeshProUGUI hintText;
    [SerializeField] TextMeshProUGUI loreText;
    [SerializeField] private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableUI() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.gameObject.SetActive(false);
    }

    public void UpdateUI(int newIndex, string newHintText, string newLoreText) 
    {
        hintText.text = newHintText;
        loreText.text = newLoreText;
        index = newIndex;
        hintText.text = relatedLockController.GetHintsString(newIndex);
        loreText.text = relatedLockController.GetLoreString(newIndex);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
