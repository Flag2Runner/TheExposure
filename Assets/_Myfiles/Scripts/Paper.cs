using System;
using TMPro;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] string hintText;
    [SerializeField] string loreText;
    [SerializeField] private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
    public string HintText { get { return hintText; } }
    public string LoreText { get { return loreText; } }

    public int GetIndex()
    {
        return index;
    }
}
