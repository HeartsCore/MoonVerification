using Moon.Asyncs;
using System;
using System.Collections.Generic;
using UnityEngine;


public class HPManager : MonoBehaviour
{
    #region PrivateData
    private List<GameObject> hpPool = new List<GameObject>();
    private int maxHP;
    #endregion


    #region Fields
    public static Action onDecrease;
    #endregion


    #region Unity Methods
    private void OnEnable()
    {
        onDecrease += Descrease;
    }

    private void OnDisable()
    {
        onDecrease -= Descrease;
    }
    #endregion


    #region MoonAsync Methods
    public AsyncState Execute(GameObject prefab, int maxHP)
    {
        var asyncChain = Planner.Chain();
        asyncChain.AddEmpty();
        this.maxHP = maxHP;
        if (hpPool.Count == maxHP)
            return asyncChain;

        gameObject.SetActive(true);
        for (int i = 0; i < maxHP; i++)
        {
            var hp = Instantiate(prefab, transform);
            hpPool.Add(hp);
        }

        return asyncChain;
    }
    #endregion


    #region Methods
    public void Descrease()
    {
        maxHP--;
        hpPool.FindLast(h => h.activeSelf == true).SetActive(false);
    }
    #endregion
}