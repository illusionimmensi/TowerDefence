﻿using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;

    public Button upgradebutton;

    public Text sellAmount;

    private Node target;

    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradebutton.interactable = true;
        } else
        {
            upgradeCost.text = "DONE";
            upgradebutton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        

        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);

    }

    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectedNode();

    }

    public void Sell ()
    {
        target.SellTurret();
        BuildManager.instance.DeselectedNode();

    }
}
