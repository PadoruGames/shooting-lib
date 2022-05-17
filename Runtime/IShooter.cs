using Padoru.Health;

namespace Padoru.Shooting
{
	public interface IShooter
	{
		void SetBehaviour(IShootBehaviour behaviour);
		void Shoot(IDamageDealer damageDealer = null);
	}
}
