using Padoru.Health;
using System;

namespace Padoru.Shooting
{
	public interface IShootBehaviour
	{
		event Action OnShoot;

		void Shoot(IDamageDealer damageDealer = null);
	}
}
