﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PillarManager : MonoBehaviour 
{
	private static PillarManager instance;
	public static PillarManager S { get { return instance; } }
	private static List<Pillar> pillars = new List<Pillar>();

	[SerializeField] private Pillar pillarTemplate;
	private float oldTime = 0;

	void Awake() { instance = this; }

	// Update is called once per frame
	void Update () 
	{	
		if(GameManager.S.IsGameOver)
			return;
		
		if(GameManager.S.isGameStart && Time.time - oldTime > 1.5f)
		{
			this.CreateZhuZi();
			oldTime = Time.time;
		}
	}
	
	void CreateZhuZi()
	{
		Pillar pillar = Instantiate(this.pillarTemplate) as Pillar;
		
		pillar.transform.position = new Vector3(12, 0, 0);
		pillar.transform.localScale = Vector3.one;
		int height = Random.Range(0, 3);
		pillar.SetHeight(height);
		pillars.Add(pillar);
	}
	
	public void DeletePillar(Pillar _pillar)
	{
		pillars.Remove(_pillar);
		Object.Destroy(_pillar.gameObject);
	}

	// 清除所有柱子
	public void ClearPillars()
	{
		foreach(var pillar in pillars)
		{
			if(pillar.gameObject != null)
				Object.Destroy(pillar.gameObject);
		}

		pillars.Clear();
	}
}