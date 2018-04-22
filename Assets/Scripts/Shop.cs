using UnityEngine;
using UnityEngine.EventSystems;
public class Shop : MonoBehaviour {


	public TurretBlueprint standardTurret;
	public TurretBlueprint missleLauncher;
	public TurretBlueprint laserBeamer;

	BuildManager buildmanager; 

	void Start()
	{
		buildmanager = BuildManager.instance;
	}

	public void SelectStandardTurret()
	{
		buildmanager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissleLauncher()
	{
		buildmanager.SelectTurretToBuild(missleLauncher);
	}

	public void SelectLaserBeamer()
	{
		buildmanager.SelectTurretToBuild(laserBeamer);
	}
}
