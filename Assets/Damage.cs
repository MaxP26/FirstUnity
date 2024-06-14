using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		var stats=collision.GetComponent<PlayerStats>();
		if(stats != null)
		{
			stats.DoDamage(1);
		}
	}
}
