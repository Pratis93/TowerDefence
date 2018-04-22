using UnityEngine;
using UnityEngine.UI;



public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	void Awake()
	{
		if (instance != null) 
		{

			Debug.LogError ("More than one buildManager in scene!");
			return;
		}

		instance = this;
	}


	public bool CanBuild 
	{
		get 
		{
			if (turretToBuild==null) 
			{
				return false;
			} else 
			{
				return true;
			}

		}
	}



	public void Upgrade()
	{

		if (PlayerStats.Money < 100)
			return;
		
		Turret[] turret  = selectedNode.turret.GetComponents<Turret> ();
		turret[0].Upgrade ();

		PlayerStats.Money -= 100;

	}


	public void Sell()
	{
		Turret[] turret  = selectedNode.turret.GetComponents<Turret> ();

		turret [0].Destroy ();
		PlayerStats.Money += 50;
	}


	public bool HasMoney 
	{
		get 
		{
			return PlayerStats.Money>=turretToBuild.cost;
		}
	}

	public void BuldTurretOn(Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost) {
			Debug.Log ("Not enought money do build that!");
			return;
		}
		
		PlayerStats.Money -= turretToBuild.cost;

		GameObject turret =  (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), node.transform.rotation);
		node.turret = turret;

		Debug.Log ("Turret build! Money left:"+PlayerStats.Money.ToString());
	}

	public void SelectNode(Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode ();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide ();
	}




	public void SelectTurretToBuild(TurretBlueprint _turret)
	{
		turretToBuild = _turret;
		DeselectNode ();
	}
}
