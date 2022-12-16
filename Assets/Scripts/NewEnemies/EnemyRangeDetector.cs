using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
	public class EnemyRangeDetector : MonoBehaviour
	{
		[SerializeField] private Enemy _colliderDetector;
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				_colliderDetector.inAttackRange = true;
				_colliderDetector.playerDetected = true;
			}
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				_colliderDetector.inAttackRange = false;
			}
		}
	}
}
