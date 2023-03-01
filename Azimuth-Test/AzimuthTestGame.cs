using Azimuth;
using Azimuth.UI;

using Raylib_cs;

using System.Net.Mime;
using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{

		private ImageWidget image;
		public override void Load()
		{
			image = new ImageWidget(Vector2.Zero, new(800, 800), "texture");
		}

		public override void Draw()
		{
			image.Draw();
		}

		public override void Update(float _deltaTime)
		{
			image.Update(Raylib.GetMousePosition());
		}

		public override void Unload()
		{
			
		}
	}
}