using Padoru.Health;

namespace Padoru.Shooting
{
	public interface IShootBehaviour
	{
		void Shoot(IDamageDealer damageDealer = null);
	}
}
