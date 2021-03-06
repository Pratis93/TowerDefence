﻿using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;

	private bool doMovement = true;

	public float panBoarderThickness = 10f;
	public float scrollspeed = 5f;

	public float minY=10;
	public float maxY=100; 


	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {

			doMovement = !doMovement;
		}

		if (!doMovement)
			return;


		


		if (Input.GetKey("w")|| Input.mousePosition.y >= Screen.height -panBoarderThickness )
		{

			transform.Translate(Vector3.forward*panSpeed*Time.deltaTime,Space.World);
		}

		if (Input.GetKey("s")|| Input.mousePosition.y <= panBoarderThickness )
		{

			transform.Translate(Vector3.back*panSpeed*Time.deltaTime,Space.World);
		}

		if (Input.GetKey("d")|| Input.mousePosition.x >= Screen.height -panBoarderThickness )
		{

			transform.Translate(Vector3.right*panSpeed*Time.deltaTime,Space.World);
		}

		if (Input.GetKey("a")|| Input.mousePosition.x <= panBoarderThickness )
		{

			transform.Translate(Vector3.left*panSpeed*Time.deltaTime,Space.World);
		}


		float scroll = Input.GetAxis ("Mouse ScrollWheel");


		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 *scrollspeed*Time.deltaTime;

		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;

	}


}
