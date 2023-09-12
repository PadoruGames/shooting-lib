using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class InstanceProjectileFactory : IProjectileFactory
	{
		private Projectile projectilePrefab;
		private readonly Transform shootPoint;

		public InstanceProjectileFactory(Projectile projectilePrefab, Transform shootPoint)
		{
			this.projectilePrefab = projectilePrefab;
			this.shootPoint = shootPoint;
		}

		public IProjectile GetProjectile()
		{
			if (projectilePrefab == null)
			{
				Debug.LogError("Cannot instantiate a null projectile");
				return null;
			}

			return Object.Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
		}
	}
}
