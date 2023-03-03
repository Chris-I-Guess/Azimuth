using Raylib_cs;

using System.Numerics;

namespace Azimuth.GameObjects
{
	public class AnimatedGameObject : GameObject
	{
		private Texture2D image;
		private int spriteAmount;

		private Rectangle display;

		private float posX = 0f;
		private float posY = 0f;

		private Vector2 size;
		private Vector2 textureSize;
		private int sizeMulti;

		private const float EPSEILON = 0.0001f;

		private float animateSpeed;
		public AnimatedGameObject(Vector2 _position, string _imageId, int _spriteAmount, float _animateSpeed, int _sizeMulti) : base()
		{
			image = Assets.Find<Texture2D>($"Textures/{_imageId}");
			spriteAmount = _spriteAmount;
			position = _position;
			
			animateSpeed = _animateSpeed;
			sizeMulti = _sizeMulti;
			
			size = new((image.width * sizeMulti) / spriteAmount, image.height * sizeMulti);
			
			textureSize = new(image.width / spriteAmount, image.height);
		}

		public override void Draw()
		{
			display = new(posX, posY, textureSize.X, textureSize.Y);

			Raylib.DrawTexturePro(image, display, new Rectangle(position.X, position.Y, size.X,size.Y), Vector2.Zero, 0, Color.WHITE);
		}

		private float speedTemp;
		

		public override void Update(float _deltaTime)
		{
			speedTemp -= _deltaTime;
			if(speedTemp < 0)
			{
				speedTemp = animateSpeed;
				if(Math.Abs(posX - (textureSize.X - image.width)) > EPSEILON)
					posX += textureSize.X;
				else
					posX = 0;
			}
		}
	}
}