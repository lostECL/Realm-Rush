using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance {get {return currentBalance;}}

    [SerializeField] TextMeshProUGUI displayBalance;


    void Awake()
    {
        currentBalance = startingBalance;
        Debug.Log("start balance:" + currentBalance);
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
        int id = displayBalance.GetInstanceID();
        Debug.Log("//bank script// current balance: " + currentBalance + "  " + id);
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
