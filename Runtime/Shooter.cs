using System;
using Padoru.Core;
using Padoru.Health;
using UnityEngine;
using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class Shooter : IShooter
	{
		private IShootBehaviour behaviour;
		private ModifiableValue<float, FloatCalculator> shootInterval;
		private float lastShootTime;

		public bool CanShoot => Time.time - lastShootTime >= shootInterval.Value;

		public event Action OnShoot;
		
		public Shooter(IShootBehaviour behaviour, ModifiableValue<float, FloatCalculator> shootInterval)
		{
			this.shootInterval = shootInterval;
			SetBehaviour(behaviour);
		}
		
		public void SetBehaviour(IShootBehaviour behaviour)
		{
			this.behaviour = behaviour;
		}

		public void Shoot(IDamageDealer damageDealer = null)
		{
			if(behaviour == null)
			{
				Debug.LogError($"Could not shoot. Shoot behaviour is null");
				return;
			}

			if (!CanShoot)
			{
				Debug.LogWarning("Called Shoot but CanShoot is not true");
				return;
			}

			lastShootTime = Time.time;

			behaviour.Shoot(damageDealer);
			
			OnShoot?.Invoke();
		}
	}
}
