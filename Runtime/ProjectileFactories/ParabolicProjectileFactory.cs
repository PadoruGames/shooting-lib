using System;
using JetBrains.Annotations;
using Padoru.Movement;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;
using Object = UnityEngine.Object;

namespace Padoru.Shooting
{
	public class ParabolicProjectileFactory : IProjectileFactory
	{
		private readonly Projectile projectilePrefab;
		[NotNull] private readonly Func<Vector3> getTargetPositionCallback;

		public ParabolicProjectileFactory(Projectile projectilePrefab, Func<Vector3> getTargetPositionCallback)
		{
			this.projectilePrefab = projectilePrefab;
			this.getTargetPositionCallback = getTargetPositionCallback;
		}

		public Projectile GetProjectile()
		{
			if (projectilePrefab == null)
			{
				Debug.LogError("Cannot instantiate a null projectile");
				return null;
			}

			var projectile = Object.Instantiate(projectilePrefab);

			var targetPosition = getTargetPositionCallback?.Invoke() ?? Vector3.zero;

			var movement = projectile.GetComponent<TargetedParabolicMovement>();

			if (movement == null)
			{
				Debug.LogError($"Projectile does not have a {typeof(TargetedParabolicMovement)} component attached.");
				return null;
			}

			movement.TargetPosition = targetPosition;
			
			return projectile;
		}
	}
}
