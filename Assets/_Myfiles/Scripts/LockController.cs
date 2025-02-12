using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class LockController : MonoBehaviour
{
    [SerializeField] private GameObject Key;
    [SerializeField] private GameObject SafeHolder;
    [SerializeField] private GameObject[] Targets;
    private bool isPadlockOnscreen;
    [SerializeField] private int[] result, correctCombination;
    [SerializeField] private string[] hints , lore;
    

    private void Start()
    {
        Key.gameObject.SetActive(false);

        hints = new string[] { $"{correctCombination[0]}", $"{correctCombination[1]}", $"{correctCombination[2]}", $"{correctCombination[3]}" };
        lore = new string[] { "", "", "", "" };
        Paper[] papers = GetComponents<Paper>();
        foreach (Paper paper in papers) 
        {
            hints[paper.GetIndex()] = $"{paper.HintText} = {correctCombination[paper.GetIndex()]}";
            lore[paper.GetIndex()] = paper.LoreText;
        }
        result = new int[] { 0, 0, 0, 0 };
        
        Rotate.Rotated += CheckResults;
    }
    public string GetHintsString(int numberIndex) 
    {
        return hints[numberIndex];
    }

    public string GetLoreString(int numberIndex) 
    {
        return lore[numberIndex];
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName) 
        {
            case "Wheel_01":
                result[0] = number; 
                break;

            case "Wheel_02":
                result[1] = number; 
                break;

            case "Wheel_03":
                result[2] = number;
                break;

            case "Wheel_04":
                result[3] = number;
                break;
        }
        if (result[0] == correctCombination[0] &&
            result[1] == correctCombination[1] &&
            result[2] == correctCombination[2] &&
            result[3] == correctCombination[3]) 
        {
            Debug.Log("Opened");
            EnableUI();
            Vector3 oldKeyPos = Key.transform.position;
            Quaternion oldRotation = Key.transform.rotation;
            Key.transform.parent = null;
            Key.transform.position = oldKeyPos;
            Key.transform.rotation = oldRotation;
            Key.gameObject.SetActive(true);
            Destroy(SafeHolder);
        }
    }
    private void OnDestroy()
    { 
        Rotate.Rotated -= CheckResults;
    }

    private void OnMouseDown()
    {
       EnableUI();
    }

    internal void EnableUI()
    {
        isPadlockOnscreen = !isPadlockOnscreen;
        if (isPadlockOnscreen)
        {
            transform.parent = Targets[1].transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else 
        {
            transform.parent = Targets[0].transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
