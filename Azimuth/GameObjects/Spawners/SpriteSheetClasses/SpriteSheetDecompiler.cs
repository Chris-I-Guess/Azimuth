using System.Drawing;

namespace Azimuth.GameObjects
{
	public class SpriteSheetDecompiler
	{
		private readonly Rectangle dest;
		private readonly string imageId;
		private readonly int spriteAmount;
		private readonly float animateSpeed;
		private readonly int sizeMulti;

		public SpriteSheetDecompiler(Rectangle _dest, string _imageId, int _spriteAmount, float _animateSpeed, int _sizeMulti)
		{
			dest = _dest;
			imageId = _imageId;
			spriteAmount = _spriteAmount;
			animateSpeed = _animateSpeed;
			sizeMulti = _sizeMulti;
		}

		private Dictionary<string, SpriteSheetDecompiler> sprites = new Dictionary<string, SpriteSheetDecompiler>();

		/// <summary>
		/// adds sprite to Dictionary only use when needing multiple spite animations for the same sprite
		/// </summary>
		public void AddSprite(string _id, SpriteSheetDecompiler _spriteSheetDecompiler) => sprites.Add(_id, _spriteSheetDecompiler);
		
		/// <summary>
		/// put into the GameObjectManager.Add(CallSprite(_id))
		/// </summary>
		public SpriteSheetDecompiler CallSprite(string _id) => sprites[_id];
	}
}