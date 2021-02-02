using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBlock : MonoBehaviour
{
	Material material;
	public bool disappear;
	public float alpha = 1f;

	private void Start()
	{
		material = GetComponent<MeshRenderer>().material;
		material.SetColor("_Color", new Color(1, .5f, .5f, alpha));
	}

	private void Update()
	{
		if(disappear)
		{
			material.SetColor("_Color", new Color(1, 0, 0, alpha));
			alpha -= 1f / 3f * Time.deltaTime;
			if (alpha < 0)
				gameObject.SetActive(false);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		PlayerController2 player = collision.gameObject.GetComponent<PlayerController2>();
		if(player)
		{
			disappear = true;
		}
	}
}
