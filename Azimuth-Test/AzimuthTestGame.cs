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
		private Button button;
		public override void Load()
		{
			button = new Button(new Vector2(300, 300), new Vector2(150,75), Button.RenderSettings.normal);
			UIManager.Add(button);
			button.SetDrawLayer(1);
			image = new ImageWidget(Vector2.Zero, new(800, 800), "texture");
			UIManager.Add(image);
			image.SetDrawLayer(0);
		}

		
		public override void Unload()
		{
			
		}
	}
}