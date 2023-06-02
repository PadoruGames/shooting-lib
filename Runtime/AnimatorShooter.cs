using System;
using Padoru.Core;
using Padoru.Health;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class AnimatorShooter : IShooter
	{
		private readonly Animator animator;
		private readonly string shootAnimationName;
		private readonly string shootEventName;
		
		private IShootBehaviour behaviour;
		private IDamageDealer damageDealer;
		private bool preparingShoot;
		private ModifiableValue<float, FloatCalculator> shootInterval;
		private float lastShootTime;

		public bool CanShoot => Time.time - lastShootTime >= shootInterval.Value;

		public event Action OnShoot;

		public AnimatorShooter(
			IShootBehaviour behaviour, 
			Animator animator, 
			AnimatorMessageHandler messageHandler, 
			string shootAnimationName,
			string shootEventName,
			ModifiableValue<float, FloatCalculator> shootInterval)
		{
			this.animator = animator;
			this.shootAnimationName = shootAnimationName;
			this.shootInterval = shootInterval;
			
			messageHandler.GetEvent(shootEventName).AddListener(AnimationShootEventHandler);
			
			SetBehaviour(behaviour);
		}

		public void SetBehaviour(IShootBehaviour behaviour)
		{
			this.behaviour = behaviour;
		}

		public void Shoot(IDamageDealer damageDealer = null)
		{
			if (animator == null)
			{
				Debug.LogError($"Could not shoot. Animator is null");
				return;
			}

			if (CanShoot && !preparingShoot)
			{
				preparingShoot = true;
				
				this.damageDealer = damageDealer;
			
				animator.SetTrigger(shootAnimationName);
			}
		}

		private void AnimationShootEventHandler()
		{
			if (behaviour == null)
			{
				Debug.LogError($"Could not shoot. Shoot behaviour is null");
				return;
			}

			lastShootTime = Time.time;
			
			preparingShoot = false;

			behaviour.Shoot(damageDealer);
			
			OnShoot?.Invoke();
		}
	}
}
