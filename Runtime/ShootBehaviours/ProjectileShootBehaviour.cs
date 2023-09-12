using Padoru.Health;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class ProjectileShootBehaviour : IShootBehaviour
	{
		private readonly IProjectileFactory factory;

		public ProjectileShootBehaviour(IProjectileFactory factory)
		{
			this.factory = factory;
		}

		public void Shoot(IDamageDealer damageDealer = null)
		{
			if (factory == null)
			{
				Debug.LogError("Cannot get projectile, factory is null");
				return;
			}

			var projectile = factory.GetProjectile();
			projectile.DamageDealer = damageDealer;
		}
	}
}
