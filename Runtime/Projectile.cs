using Padoru.Health;
using UnityEngine;

namespace Padoru.Shooting
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private float speed = 3f;

		public IDamageDealer DamageDealer { get; set; }

		private void Awake()
		{
			Destroy(gameObject, 5f);
		}

		private void Update()
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}
}
