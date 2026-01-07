using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    [SerializeField] private InputField nameTextBox1, nameTextBox2;
    [SerializeField] private MoneyManager moneyManager;

    private float money, lostMoney;
    private float moneyCal;

    public static bool firstAfterGameplay = true;

    public void SaveData_ButtonClick()
    {
        Time.timeScale = 1;

        PlayerPrefs.SetString("name1", nameTextBox1.text);
        PlayerPrefs.SetString("name2", nameTextBox2.text);
        Debug.Log("Your Name is " + PlayerPrefs.GetString("name1"));
        Debug.Log("Your Name is " + PlayerPrefs.GetString("name2"));

        money = moneyManager.money;
        lostMoney = moneyManager.lostMoney;
        moneyCal = money + lostMoney;

        PlayerPrefs.SetString("moneyLeft", money.ToString());
        PlayerPrefs.SetString("moneyLost", lostMoney.ToString());
        PlayerPrefs.SetFloat("moneyCal", moneyCal);
        Debug.Log("Your Money Left is " + PlayerPrefs.GetString("moneyLeft"));
        Debug.Log("Your Lost Money is " + PlayerPrefs.GetString("moneyLost"));

        if (firstAfterGameplay)
        {
            firstAfterGameplay = false;
            SceneManager.LoadScene("AfterGameplay_First");
        }
        else
            SceneManager.LoadScene("AfterGameplay");
    }
}
