using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [Header("All Access Player")]
    [SerializeField] [HideInInspector] private int AllMoney;
    [SerializeField] [HideInInspector] private int Ammo;
    public GameObject panel_1;
    [Space(15)]
    [Header("Text Access")]
    [SerializeField] private Text _textRifle;
    [SerializeField] private Text _textSniperRifle;
    [SerializeField] private Text _textUZI;
    [SerializeField] private Text _textAmmo;
    [Space(10)]
    [Header("Access to Use")]
    [SerializeField] private GameObject _butRifle;
    [SerializeField] private GameObject _butSniperRifle;
    [SerializeField] private GameObject _butUZI;
    [Space(20)]
    [Header("Access to Buy")]
    [SerializeField] private bool isBuyRifle;
    [SerializeField] private bool isBuySniperRifle;
    [SerializeField] private bool isBuyUZI;
    [Space(20)]
    [Header("Using Guns")]
    [SerializeField] private bool isRifle;
    [SerializeField] private bool isSniperRifle;
    [SerializeField] private bool isUZI;
    private void Update()
    {

        if (isBuyRifle == true)
        {
            _butRifle.SetActive(true);
        }
        if (isRifle == true)
        {
            _butRifle.SetActive(false);
        }

        if (isBuySniperRifle == true)
        {
            _butSniperRifle.SetActive(true);
        }
        if (isSniperRifle == true)
        {
            _butSniperRifle.SetActive(false);
        }

        if (isBuyUZI == true)
        {
            _butUZI.SetActive(true);
        }
        if (isUZI == true)
        {
            _butUZI.SetActive(false);
        }
    }
    public void ChangePanel1()
    {
        if (panel_1.activeSelf == false)
        {
            panel_1.active = true;
        }
        else
        {
            panel_1.active = false;
        }
    }

    public void BuyAmmo()
    {
        Ammo += 10;
    }
    public void BuyRifle()
    {
        isBuyRifle = true;
    }
    public void BuySniperRifle()
    {
        isBuySniperRifle = true;
    }
    public void BuyUZI()
    {
        isBuyUZI = true;
    }

    public void UseRifle()
    {
        isRifle = true;
    }
    public void UseSniperRifle()
    {
        isSniperRifle = true;
    }
    public void UseUZI()
    {
        isUZI = true;
    }

    [HideInInspector] private int _empty;
}
