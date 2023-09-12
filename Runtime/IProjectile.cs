using Padoru.Health;
using UnityEngine;

namespace Padoru.Shooting
{
	public interface IProjectile
	{
		Transform Transform { get; }
		
		IDamageDealer DamageDealer { get; set; }
	}
}
