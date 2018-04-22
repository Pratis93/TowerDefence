using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{
	public GameObject MyUI;

	public bool toogle=false;

	 

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F1))
		{
			Toggle ();
		}

	}


	public void  Toggle()
	{
		toogle = !toogle;

		MyUI.SetActive (toogle);

		if (MyUI.activeSelf)
		{
			Time.timeScale = 0f;
		} else 
		{
			Time.timeScale = 1f;
		}
	}


	public void Retry()
	{
		Toggle ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}


	public void Menu()
	{

		Debug.Log ("Menu");


		}
}

