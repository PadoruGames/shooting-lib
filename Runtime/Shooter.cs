using Padoru.Health;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Shooting
{
	public class Shooter : IShooter
	{
		private IShootBehaviour behaviour;

		public Shooter(IShootBehaviour behaviour)
		{
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

			behaviour.Shoot(damageDealer);
		}
	}
}
