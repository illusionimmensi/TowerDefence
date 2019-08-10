
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    
    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("more than one buildmanager in scene!");
        }
        instance = this;
    }

   

    public GameObject buildEffect;

    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;

    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null;  } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    
    
    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectedNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectedNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

   public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        

        DeselectedNode();
    }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }

    
}
