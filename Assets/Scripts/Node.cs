using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour {

	[Header("Unity Color")]
	public Color hoverColor;
	public Color startColor;
	public Color notEnoughtColor;

	[Header("Unity possiton Offset")]
	public Vector3 positonOffSet;

	[Header("Unity Object to Add")]
	public GameObject turretPreFab;

	[Header("Optional")]
	public GameObject turret;

	BuildManager buildManager;
	private Renderer rend;


	void Start()
	{
		rend = GetComponent<Renderer> ();
		buildManager = BuildManager.instance;
	}


	public Vector3 GetBuildPosition()
	{
		return transform.position + positonOffSet;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		
	
		 
		//gdy turret istnieje wlacz menu ugrade/sell
		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild) 
		{
			return;
		}
			

		buildManager.BuldTurretOn(this);

	}





	void OnMouseEnter()
	{
		//if (EventSystem.current.IsPointerOverGameObject())
		//	return;

		if (!buildManager.CanBuild) {
			return;
		}

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else 
		{
			rend.material.color = notEnoughtColor;
		}


	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
