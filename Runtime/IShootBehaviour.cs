using Padoru.Health;

namespace Padoru.Shooting
{
	public interface IShootBehaviour
	{
		bool Shoot(IDamageDealer damageDealer = null);
	}
}
