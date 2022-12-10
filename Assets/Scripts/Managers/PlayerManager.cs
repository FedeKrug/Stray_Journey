using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Player
{
	public class PlayerManager : MonoBehaviour, IHealth
	{
		public static PlayerManager instance;
		[SerializeField] public FloatSO playerHealth;
		[SerializeField] private BulletPool _objectPooling_Bullet;
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

			EventManager.instance.shootPoolingNormal.AddListener(ShootingPoolingHandler);
			EventManager.instance.shootPoolingSpecial.AddListener(ShootingPoolingHandler);
			

			EventManager.instance.playerDamagedEvent.AddListener(TakeDamage);
			EventManager.instance.playerCuredEvent.AddListener(IncreaseHealth);
		}
		private void OnDisable()
		{
			EventManager.instance.normalShootingEvent.RemoveListener(ShootingHandler);
			EventManager.instance.specialShootingEvent.RemoveListener(ShootingHandler);

			EventManager.instance.playerDamagedEvent.RemoveListener(TakeDamage);
			EventManager.instance.playerCuredEvent.RemoveListener(IncreaseHealth);

			EventManager.instance.shootPoolingNormal.RemoveListener(ShootingPoolingHandler);
			EventManager.instance.shootPoolingSpecial.RemoveListener(ShootingPoolingHandler);
		}

		#endregion

		public void ShootingHandler(List<GameObject> bulletGenerators, GameObject bullet)
		{
			for (int i = 0; i < bulletGenerators.Count; i++)
			{
				if (bullet)
				{
					GameObject _bullet = Instantiate(bullet, bulletGenerators[i].transform.position, bulletGenerators[i].transform.rotation);
					//GameObject _bullet = BulletPool.instance.RequestBullets();
					_bullet.transform.position = bulletGenerators[i].transform.position;
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
			if (playerHealth.value <= 0)
			{
				Debug.Log("Player Death");
			}
		}
		public void ShootingPoolingHandler(List<GameObject> bulletGens)
		{
			for (int i = 0; i < bulletGens.Count; i++)
			{

				GameObject _bullet = BulletPool.instance.RequestBullets();
				_bullet.transform.position = bulletGens[i].transform.position;
				_bullet.transform.rotation = bulletGens[i].transform.rotation;
				Debug.Log("Disparo");
				//aplicar object pooling para mejor performance

			}
		}
	}
}
