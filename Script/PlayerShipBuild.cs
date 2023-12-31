﻿using UnityEngine;

public class PlayerShipBuild : MonoBehaviour 
{
	[SerializeField]
	GameObject[] shopButtons;
	GameObject target;
 	GameObject tmpSelection;
	GameObject textBoxPanel;
	
	void Start()
	{
		textBoxPanel = GameObject.Find("textBoxPanel");
		TurnOffSelectionHighlights();
	}
	
	GameObject ReturnClickedObject (out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray.origin, ray.direction * 100, out hit)) 
		{
			target = hit.collider.gameObject;
		}
		return target;
	}
	
	void TurnOffSelectionHighlights()
	{
		for (int i = 0; i < shopButtons.Length; i++)
		{
			shopButtons[i].SetActive(false);
		}
	}

	void UpdateDescriptionBox()
	{
		textBoxPanel.transform.Find("name").gameObject.GetComponent<TextMesh>().text = tmpSelection.GetComponentInParent<ShopPiece>().ShopSelection.iconName;
		textBoxPanel.transform.Find("desc").gameObject.GetComponent<TextMesh>().text = tmpSelection.GetComponentInParent<ShopPiece>().ShopSelection.description;	
	}
	void Select()
	{
		tmpSelection = target.transform.Find("SelectionQuad").gameObject;
		tmpSelection.SetActive(true);
	}
	
	public void AttemptSelection()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hitInfo;
			target = ReturnClickedObject (out hitInfo);

			if (target != null)
			{
				if (target.transform.Find("itemText"))
				{
						TurnOffSelectionHighlights();
						Select();
						UpdateDescriptionBox();
						
				 }
			}
		}
 	}

	void Update()
	{
		AttemptSelection();
	}
}