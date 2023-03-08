using Raylib_cs;

using System.Numerics;


namespace Azimuth.GameObjects
{
	public class SingleSpriteGameObject : GameObject
	{
		public Vector2 Size { get; private set; }
		private readonly Texture2D image;
		
		public SingleSpriteGameObject(Vector2 _position, string _imageId, int _sizeMulti)
		{
			position = _position;
			image = Assets.Find<Texture2D>($"Textures/{_imageId}");
			Size = new((image.width * _sizeMulti), image.height * _sizeMulti);
		}
		public override void Draw()
		{
			RaylibExt.DrawTexture(image, position.X, position.Y, Size.X, Size.Y, Color.WHITE); 
		}
	}
}