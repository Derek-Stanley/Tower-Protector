using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBlanace;
    [SerializeField] TextMeshProUGUI displayBalance;
    void Awake() 
    {
        UpdateDisplay();
        currentBlanace = startingBalance;
    }
    
    public int CurrentBalance{ get {return currentBlanace;}}

    public void Deposit(int depsit)
    {
        currentBlanace += Mathf.Abs(depsit);
        UpdateDisplay();
    }
    public void WithDraw(int withdraw)
    {
        currentBlanace -= Mathf.Abs(withdraw);
        UpdateDisplay();
        if(currentBlanace <= 0)
        {
            ReloadScene();
        }
    }
    void UpdateDisplay()
    {
        displayBalance.text = "Gold : " + currentBlanace;
    }

    void ReloadScene()
    {
       Scene currentScene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(currentScene.buildIndex);
    }
}
