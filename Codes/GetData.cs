using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public Text nameBox1, nameBox2, moneyLeftBox, moneyLostBox, moneyBondBox, moneyMutualFundBox, moneyDerivativeBox, moneyShareBox;

    void Start()
    {
        float moneyBond1 = PlayerPrefs.GetFloat("moneyCal");
        float moneyBond2 = PlayerPrefs.GetFloat("moneyCal");
        float moneyMutualFund1 = PlayerPrefs.GetFloat("moneyCal");
        float moneyMutualFund2 = PlayerPrefs.GetFloat("moneyCal");
        float moneyDerivative1 = PlayerPrefs.GetFloat("moneyCal");
        float moneyDerivative2 = PlayerPrefs.GetFloat("moneyCal");
        float moneyShare1 = PlayerPrefs.GetFloat("moneyCal");
        float moneyShare2 = PlayerPrefs.GetFloat("moneyCal");
        moneyBond1 = moneyBond1 * 102 / 100;
        moneyBond2 = moneyBond2 * 105 / 100;
        moneyMutualFund1 = moneyMutualFund1 * 105 / 100;
        moneyMutualFund2 = moneyMutualFund2 * 107 / 100;
        moneyDerivative1 = moneyDerivative1 * 110 / 100;
        moneyDerivative2 = moneyDerivative2 * 115 / 100;
        moneyShare1 = moneyShare1 * 107 / 100;
        moneyShare2 = moneyShare2 * 111 / 100;


        nameBox1.text = PlayerPrefs.GetString("name1");
        nameBox2.text = PlayerPrefs.GetString("name2");
        moneyLeftBox.text = PlayerPrefs.GetString("moneyLeft");
        moneyLostBox.text = PlayerPrefs.GetString("moneyLost");
        moneyBondBox.text = " [ " + moneyBond1 + " - " + moneyBond2 + " ] ";
        moneyMutualFundBox.text = " [ " + moneyMutualFund1 + " - " + moneyMutualFund2 + " ] ";
        moneyDerivativeBox.text = " [ " + moneyDerivative1 + " - " + moneyDerivative2 + " ] ";
        moneyShareBox.text = " [ " + moneyShare1 + " - " + moneyShare2 + " ] ";
    }
}
