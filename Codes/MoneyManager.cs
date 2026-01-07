using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] public static MoneyManager moneyManager;

    [SerializeField] private Text moneyText;

    [SerializeField] private int starMoney = 1000;
    [SerializeField] public int money;
    [SerializeField] public int lostMoney;

    [SerializeField] GameObject objOnOff;

    private void Awake()
    {
        moneyManager = this;
    }

    void Start()
    {
        money = starMoney;
        moneyText.text = money.ToString();
    }


    public void GetMoney(int getMoney)
    {

        money += getMoney;
        moneyText.text = money.ToString();
    }

    public void ReduceMoney(int reduceMoney)
    {

        money -= reduceMoney;
        moneyText.text = money.ToString();
    }

    public void LostMoney(int reduceMoney)
    {
        lostMoney += reduceMoney;
    }


    void Update()
    {
        ReduceTime();
    }

    public void ReduceTime()
    {

        if (money <= 0)
        {
            Time.timeScale = 0f;
            objOnOff.SetActive(true);
        }
    }
}
