using Padoru.Core;
using Padoru.Health;
using UnityEngine;
using System;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class ProjectileShootBehaviour : IShootBehaviour
	{
		private IProjectileFactory factory;
		private Transform shootPoint;
		private ModifiableValue<float, FloatCalculator> shootInterval;
		private float lastShootTime;

		public event Action OnShoot;

		public ProjectileShootBehaviour(IProjectileFactory factory, ModifiableValue<float, FloatCalculator> shootInterval, Transform shootPoint)
		{
			this.factory = factory;
			this.shootInterval = shootInterval;
			this.shootPoint = shootPoint;
		}

		public bool Shoot(IDamageDealer damageDealer = null)
		{
			if (factory == null)
			{
				Debug.LogError("Cannot get projectile, factory is null");
				return false;
			}

			if (Time.time - lastShootTime < shootInterval.Value)
			{
				return false;
			}

			lastShootTime = Time.time;
			var projectile = factory.GetProjectile();
			projectile.transform.SetPositionAndRotation(shootPoint.position, shootPoint.rotation);
			projectile.DamageDealer = damageDealer;

			OnShoot?.Invoke();

			return true;
		}
	}
}
