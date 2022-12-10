using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Player
{
	public class PlayerManager : MonoBehaviour, IHealth
	{
		public static PlayerManager instance;
		[SerializeField] public FloatSO playerHealth;
		#region Singleton and Awake
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
		#endregion

		#region Subscribe and Unsubscribe to EventManager
		private void OnEnable()
		{
			EventManager.instance.normalShootingEvent.AddListener(ShootingHandler);
			EventManager.instance.specialShootingEvent.AddListener(ShootingHandler);

			EventManager.instance.playerDamagedEvent.AddListener(TakeDamage);
			EventManager.instance.playerCuredEvent.AddListener(IncreaseHealth);
		}
		private void OnDisable()
		{
			EventManager.instance.normalShootingEvent.RemoveListener(ShootingHandler);
			EventManager.instance.specialShootingEvent.RemoveListener(ShootingHandler);

			EventManager.instance.playerDamagedEvent.RemoveListener(TakeDamage);
			EventManager.instance.playerCuredEvent.RemoveListener(IncreaseHealth);
		}

		#endregion

		public void ShootingHandler(List<GameObject> bulletGenerators, GameObject bullet)
		{
			for (int i = 0; i < bulletGenerators.Count; i++)
			{
				if (bullet)
				{
					GameObject _bullet = Instantiate(bullet, bulletGenerators[i].transform.position, bulletGenerators[i].transform.rotation);
					Debug.Log("Disparo");
					//aplicar object pooling para mejor performance
				}
			}
		}
		public void TakeDamage(float damage)
		{
			playerHealth.value -= damage;
			Debug.Log("Player Damaged");
			CheckDeath();
		}

		public void IncreaseHealth(float healthBooster)
		{
			playerHealth.value += healthBooster;
		}

		public void CheckDeath()
		{
			if (playerHealth.value <=0)
			{
				Debug.Log("Player Death");
			}
		}
	}

}
