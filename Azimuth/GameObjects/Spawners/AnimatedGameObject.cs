using MathLib;

using Raylib_cs;

namespace Azimuth.GameObjects
{
	public class AnimatedGameObject : GameObject
	{
		private const float EPSILON = float.Epsilon;
		
		private float animateSpeed;
		private readonly int sizeMulti;
		private int spriteAmount;
		public Vec2 Size { get; private set; }

		private readonly Texture2D image;

		private Rectangle source;
		private Rectangle textureRec;
		
		private readonly Dictionary<string, Rectangle> locations = new();
		
		/// <summary>
		/// To put Id to a rectangle to make less messy when changing between spriteAnimation
		/// </summary>
		public void AddRectangle(string _id, Rectangle _rectangle) => locations.Add(_id, _rectangle);
		
		/// <summary>
		/// Be able to call the Rectangle that you made in AddRectangle()
		/// </summary>
		public Rectangle CallRectangle(string _id) => locations[_id];

		public AnimatedGameObject(Rectangle? _source, Vec2 _position, string _imageId, int _spriteAmount, float _animateSpeed, int _sizeMulti)
		{
			image = Assets.Find<Texture2D>($"Textures/{_imageId}");
			
			position = _position;
			animateSpeed = _animateSpeed;
			sizeMulti = _sizeMulti;
			spriteAmount = _spriteAmount;
			
			source = _source ?? new Rectangle(0, 0, image.width, image.height);
			UpdateMath();
		}
		/// <summary>
		/// This is only works with sprite sheets
		/// </summary>
		public void ChangeAnimation(Rectangle? _source, int? _spriteAmount, float? _animateSpeed)
		{
			float height = source.height;

			source = _source ?? source;
			
			position.y = (position.y + height) - source.height;
			
			animateSpeed = _animateSpeed ?? animateSpeed;
			spriteAmount = _spriteAmount ?? spriteAmount;
			
			UpdateMath();
		}
		
		internal void UpdateMath()
		{
			textureRec = new Rectangle(source.x, source.y, source.width / spriteAmount, source.height);
			Size = new Vec2((source.width * sizeMulti) / spriteAmount, source.height * sizeMulti);
		}
		
		public bool CheckIfInAnimation(string _id)
		{
			Rectangle foo = CallRectangle(_id);
			
			return (int)source.x == (int)foo.x && (int)source.y == (int)foo.y;
		}

	#region Draw & Update Functions

		public override void Draw()
		{
			Raylib.DrawTexturePro(image,textureRec,new Rectangle(position.x, position.y, Size.x,Size.y), Vec2.zero, 0, Color.WHITE);
		}
		
		private float speedTemp;
		

		public override void Update(float _deltaTime)
		{
			speedTemp -= _deltaTime;
			if(speedTemp < 0)
			{
				speedTemp = animateSpeed;
				if(Math.Abs(textureRec.x - (source.width - textureRec.width)) > EPSILON)
					textureRec.x += textureRec.width;
				else
					textureRec.x = source.x;
			}
		}

	#endregion
	}
}