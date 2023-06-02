using System;
using Padoru.Movement;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;
using Object = UnityEngine.Object;

namespace Padoru.Shooting
{
	public class InstanceTargetProjectileFactory : IProjectileFactory
	{
		private readonly Projectile projectilePrefab;
		private readonly Func<Transform> getTargetCallback;

		public InstanceTargetProjectileFactory(Projectile projectilePrefab, Func<Transform> getTargetCallback)
		{
			this.projectilePrefab = projectilePrefab;
			this.getTargetCallback = getTargetCallback;
		}

		public Projectile GetProjectile()
		{
			if (projectilePrefab == null)
			{
				Debug.LogError("Cannot instantiate a null projectile");
				return null;
			}

			var projectile = Object.Instantiate(projectilePrefab);

			var target = getTargetCallback?.Invoke();

			if (target == null)
			{
				Debug.LogError($"Provided target is null");
				return null;
			}

			var movement = projectile.GetComponent<TargetedParabolicMovement>();

			if (movement == null)
			{
				Debug.LogError($"Projectile does not have a {typeof(TargetedParabolicMovement)} component attached.", target.gameObject);
				return null;
			}

			movement.Target = target;
			
			return projectile;
		}
	}
}
