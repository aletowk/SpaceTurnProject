using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResources
{
    public int m_foodAmount;
    public int m_metalAmount;
    public int m_hydrogenAmount;
    public int m_uraniumAmount;

    public void BarrenInit()
    {
        m_foodAmount = 0;
        m_metalAmount = 100;
        m_hydrogenAmount = 0;
        m_uraniumAmount = 50;
    }
    public void LushInit()
    {
        m_foodAmount = 100;
        m_metalAmount = 25;
        m_hydrogenAmount = 25;
        m_uraniumAmount = 25;
    }
    public void GasGiantInit()
    {
        m_foodAmount = 0;
        m_metalAmount = 0;
        m_hydrogenAmount = 150;
        m_uraniumAmount = 0;
    }
    public void InitColony()
    {
        m_foodAmount = 10;
        m_metalAmount = 10;
        m_hydrogenAmount = 10;
        m_uraniumAmount = 10;
    }

    public override string  ToString()
    {
        string toRet;
        toRet =  "Food    : " + m_foodAmount.ToString() + "\n";
        toRet += "Metal   : " + m_metalAmount.ToString() + "\n";
        toRet += "Hydrogen: " + m_hydrogenAmount.ToString() + "\n";
        toRet += "Uranium : " + m_uraniumAmount.ToString() + "\n";
        return toRet;
    }
}
