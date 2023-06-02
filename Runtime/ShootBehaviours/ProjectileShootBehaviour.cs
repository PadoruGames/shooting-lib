using Padoru.Health;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class ProjectileShootBehaviour : IShootBehaviour
	{
		private readonly IProjectileFactory factory;
		private readonly Transform shootPoint;

		public ProjectileShootBehaviour(IProjectileFactory factory, Transform shootPoint)
		{
			this.factory = factory;
			this.shootPoint = shootPoint;
		}

		public void Shoot(IDamageDealer damageDealer = null)
		{
			if (factory == null)
			{
				Debug.LogError("Cannot get projectile, factory is null");
				return;
			}

			var projectile = factory.GetProjectile();
			projectile.transform.SetPositionAndRotation(shootPoint.position, shootPoint.rotation);
			projectile.DamageDealer = damageDealer;
		}
	}
}
