using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmallPillarBehaviour : MonoBehaviour
{
	public enum PushType
	{
		Front,
		Back,
		Left,
		Right
	}

	/*[SerializeField] private GameObject pillarPushPointFront;
	[SerializeField] private GameObject pillarPushPointBack;
	[SerializeField] private GameObject pillarPushPointLeft;
	[SerializeField] private GameObject pillarPushPointRight;

	[SerializeField] private BoxCollider pillarPushPointFrontCollider;
	[SerializeField] private BoxCollider pillarPushPointBackCollider;
	[SerializeField] private BoxCollider pillarPushPointLeftCollider;
	[SerializeField] private BoxCollider pillarPushPointRightCollider;*/
	
	public PushType pushType;
	public bool pushFront;
	public bool pushBack;
	public bool pushLeft;
	public bool pushRight;
	public bool pushed;
	public Animator smallPillarAnim;
	public YuutaPlayerBehaviour Yuuta;
	public TextMeshPro number;
	public string numberText;

	// Use this for initialization
	void Start ()
	{
		smallPillarAnim = transform.parent.parent.GetComponent<Animator>();
		Yuuta = FindObjectOfType<YuutaPlayerBehaviour>();
		if (number != null)
		{
			number = transform.parent.GetComponentInChildren<TextMeshPro>();
			number.text = numberText;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Yuuta)
		{
			Yuuta = FindObjectOfType<YuutaPlayerBehaviour>();
		}
		
		if (!pushed && pushFront || pushBack || pushLeft || pushRight)
		{
			pushed = true;
		}

		//PlayAnimation();
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Yuuta"))
		{
			switch (pushType)
			{
				case PushType.Front:
					if (Input.GetButtonDown("R1") && !pushed)
					{
						Yuuta.GetComponent<Animator>().SetBool("pushed", true);
						StartCoroutine(WaitBeforeChangingAnimation());
						pushFront = true;
						smallPillarAnim.SetBool("fall back", true);
						Debug.Log("Pushed front point, falling back");
					}
					break;

				case PushType.Back:
				{
					if (Input.GetButtonDown("R1") && !pushed)
					{
						Yuuta.GetComponent<Animator>().SetBool("pushed", true);
						StartCoroutine(WaitBeforeChangingAnimation());
						pushBack = true;
						smallPillarAnim.SetBool("fall front", true);
						Debug.Log("Pushed back point, falling front");
					}
					break;
				}

				case PushType.Left:
				{
					if (Input.GetButtonDown("R1") && !pushed) 
					{
						Yuuta.GetComponent<Animator>().SetBool("pushed", true);
						StartCoroutine(WaitBeforeChangingAnimation());
						pushLeft = true;
						smallPillarAnim.SetBool("fall right", true);
						Debug.Log("Pushed left point, falling right");
					}
					break;
				}

				case PushType.Right:
				{
					if (Input.GetButtonDown("R1") && !pushed)
					{
						Yuuta.GetComponent<Animator>().SetBool("pushed", true);
						StartCoroutine(WaitBeforeChangingAnimation());
						pushRight = true;
						smallPillarAnim.SetBool("fall left", true);
						Debug.Log("Pushed right point, falling left");
					}
					break;
				}
			}
		}
	
	}
	
	private void PlayAnimation()
	{
		// if (pushFront)
		// {
		// 	smallPillarAnim.SetBool("fall back", true);
		// }
		// else if (!pushFront)
		// {
		// 	smallPillarAnim.SetBool("fall back", false);
		// }
	
		if (pushBack)
		{
			smallPillarAnim.SetBool("fall front", true);
			Debug.Log("setting fall front.");
		}
		else if (!pushBack)
		{
			smallPillarAnim.SetBool("fall front", false);
		}
	
		// if (pushLeft)
		// {
		// 	smallPillarAnim.SetBool("fall right", true);
		// }
		// else if (!pushLeft)
		// {
		// 	smallPillarAnim.SetBool("fall right", false);
		// }
		//
		// if (pushRight)
		// {
		// 	smallPillarAnim.SetBool("fall left", true);
		// }
		// else if (!pushRight)
		// {
		// 	smallPillarAnim.SetBool("fall left", false);
		// }
	}
	
	IEnumerator WaitBeforeChangingAnimation()
	{
		yield return new WaitForSeconds(0.8f);
		Yuuta.GetComponent<Animator>().SetBool("pushed", false);
	}
}
