using System;
using Padoru.Health;

namespace Padoru.Shooting
{
	public interface IShooter
	{
		bool CanShoot { get; }
		
		event Action OnShoot;
		
		void SetBehaviour(IShootBehaviour behaviour);
		
		void Shoot(IDamageDealer damageDealer = null);
	}
}
