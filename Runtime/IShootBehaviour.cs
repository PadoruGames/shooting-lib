using Padoru.Health;

namespace Padoru.Shooting
{
	public interface IShootBehaviour
	{
		bool CanShoot { get; }
		
		void Shoot(IDamageDealer damageDealer = null);
	}
}
