using Raylib_cs;

using System.Numerics;

namespace Azimuth.GameObjects
{
	public class AnimatedGameObject : GameObject
	{
		private readonly Texture2D image;
		private readonly int spriteAmount;

		private Rectangle display;

		private float texturePosX = 0f;
		public Vector2 Size { get; private set; }
		
		private readonly Vector2 textureSize;
		private readonly int sizeMulti;

		private const float EPSILON = 0.0001f;

		private readonly float animateSpeed;
		public AnimatedGameObject(Vector2 _position, string _imageId, int _spriteAmount, float _animateSpeed, int _sizeMulti)
		{
			image = Assets.Find<Texture2D>($"Textures/{_imageId}");
			spriteAmount = _spriteAmount;
			position = _position;
			
			animateSpeed = _animateSpeed;
			sizeMulti = _sizeMulti;
			
			Size = new((image.width * sizeMulti) / spriteAmount, image.height * sizeMulti);
			
			textureSize = new(image.width / spriteAmount, image.height);
		}

		public override void Draw()
		{
			display = new(texturePosX, 0, textureSize.X, textureSize.Y);

			Raylib.DrawTexturePro(image, display, new Rectangle(position.X, position.Y, Size.X,Size.Y), Vector2.Zero, 0, Color.WHITE);
		}

		private float speedTemp;
		

		public override void Update(float _deltaTime)
		{
			speedTemp -= _deltaTime;
			if(speedTemp < 0)
			{
				speedTemp = animateSpeed;
				if(Math.Abs(texturePosX - (textureSize.X - image.width)) > EPSILON)
					texturePosX += textureSize.X;
				else
					texturePosX = 0;
			}
		}
	}
}