using Padoru.Health;
using UnityEngine;

namespace Padoru.Shooting
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private int damage = 1;

		public IDamageDealer DamageDealer { get; set; }

		private void Awake()
		{
			Destroy(gameObject, 5f);
		}

		private void OnCollisionEnter(Collision collision)
		{
			OnColision(collision.collider.gameObject);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			OnColision(collision.collider.gameObject);
		}

		private void OnColision(GameObject go)
		{
			var health = go.GetComponent<IHealth>();
			if (health != null)
			{
				health.Damage(damage, DamageDealer);
			}

			Destroy(gameObject);
		}
	}
}
