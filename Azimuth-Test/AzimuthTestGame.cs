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
		
		private void OnClickButton()
		{
			Console.WriteLine("Hello WOrld!");
		}
		public override void Load()
		{
			int counter = 0; 
			
			button = new Button(new Vector2(300, 300), new Vector2(150,75), new Button.RenderSettings("hello", 50, null, Color.WHITE));
			UIManager.Add(button);
			button.SetDrawLayer(1);
			
			image = new ImageWidget(Vector2.Zero, new(800, 800), "texture");
			
			image.SetDrawLayer(0);
			
			button.AddListener(OnClickButton);
			button.AddListener(() =>
			{
				if(counter % 2 == 0)
					UIManager.Add(image);
				else 
					UIManager.Remove(image);

				counter++;
				Console.WriteLine("WEEEWOOOO!");
				
				/*button.Interactable = false;*/
			});
		}

		
		public override void Unload()
		{
			
		}
	}
}