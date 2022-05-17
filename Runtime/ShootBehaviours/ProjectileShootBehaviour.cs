using Padoru.Core;
using Padoru.Health;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class ProjectileShootBehaviour : IShootBehaviour
	{
		private IProjectileFactory factory;
		private Transform shootPoint;
		private ModifiableValue<float, FloatCalculator> shootInterval;
		private float lastShootTime;

		public ProjectileShootBehaviour(IProjectileFactory factory, ModifiableValue<float, FloatCalculator> shootInterval, Transform shootPoint)
		{
			this.factory = factory;
			this.shootInterval = shootInterval;
			this.shootPoint = shootPoint;
		}

		public void Shoot(IDamageDealer damageDealer = null)
		{
			if (factory == null)
			{
				Debug.LogError("Cannot get projectile, factory is null");
				return;
			}

			if (Time.time - lastShootTime < shootInterval.Value)
			{
				return;
			}

			lastShootTime = Time.time;
			var projectile = factory.GetProjectile();
			projectile.transform.SetPositionAndRotation(shootPoint.position, shootPoint.rotation);
			projectile.DamageDealer = damageDealer;
		}
	}
}
