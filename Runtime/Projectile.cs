using Padoru.Health;
using UnityEngine;

namespace Padoru.Shooting
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private int damage = 1;
		[SerializeField] private float destroyDelay = 5f;
		[SerializeField] private GameObject impactPrefab;

		public IDamageDealer DamageDealer { get; set; }

		private void Awake()
		{
			Destroy(gameObject, destroyDelay);
		}

		private void OnCollisionEnter(Collision collision)
		{
			OnCollision(collision.collider.gameObject);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			OnCollision(collision.collider.gameObject);
		}

		private void OnCollision(GameObject go)
		{
			var health = go.GetComponent<IHealth>();
			
			health?.Damage(damage, DamageDealer);

			if(impactPrefab != null)
            {
				Instantiate(impactPrefab, transform.position, Quaternion.identity);
            }

			Destroy(gameObject);
		}
	}
}
