using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class InstanceProjectileFactory : IProjectileFactory
	{
		private Projectile projectilePrefab;

		public InstanceProjectileFactory(Projectile projectilePrefab)
		{
			this.projectilePrefab = projectilePrefab;
		}

		public Projectile GetProjectile()
		{
			if (projectilePrefab == null)
			{
				Debug.LogError("Cannot instantiate a null projectile");
				return null;
			}

			return Object.Instantiate(projectilePrefab);
		}
	}
}
