using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage;
	[Range(-250, 250f)] public float speed;
	[SerializeField, Tooltip("Change damage " +
	"with a boost later"), Range(0, 25f)]
	private float damageModifier;
	[Header("Destroying Bullets: ")]
	[SerializeField, Range(0, 15f)] private float _maxTimeToDestroy;
	private float timeToDestroy;
	[SerializeField] private Rigidbody2D _rb2d;
	[SerializeField] private Animator _anim;
	[SerializeField] private AudioSource _aSource;

	private void OnEnable()
	{
		_rb2d.velocity = Vector2.up * speed;
	}

	private void Update()
	{

		//      timeToDestroy -= Time.deltaTime;
		//      if (timeToDestroy<=0)
		//{
		//          timeToDestroy = _maxTimeToDestroy;
		//          this.gameObject.SetActive(false);
		//}
		Destroy(gameObject, _maxTimeToDestroy);
	}

	private void FixedUpdate()
	{
		_rb2d.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);

	}

}

public enum BulletType
{
	Normal,
	Explosion,
	Dispersion,

}