using System.Numerics;

namespace Azimuth.GameObjects
{
	public abstract class GameObject
	{
		public Vector2 position;

		public abstract void Load();
		public abstract void Draw();
		public abstract void Update(float _deltaTime);

		public abstract void Unload();
	}
}