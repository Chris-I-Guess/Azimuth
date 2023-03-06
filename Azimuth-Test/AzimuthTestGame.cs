using Azimuth;
using Azimuth.GameObjects;
using Azimuth.UI;

using Raylib_cs;

using System.Net.Mime;
using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{

		private ImageWidget image;
		private ButtonWidget buttonWidget;
		private TextWidget text;
		private AnimatedGameObject dino;

		private AnimatedGameObject dinoButStill;

		private AnimatedGameObject testdinomulti;
		
		private void OnClickButton()
		{
			Console.WriteLine("Hello WOrld!");
		}
		public override void Load()
		{
			int counter = 0;
			
			buttonWidget = new ButtonWidget(new Vector2(300, 300), new Vector2(150,75),"hello" , new ButtonWidget.RenderSettings(50, null, Color.WHITE));
			UIManager.Add(buttonWidget);
			buttonWidget.SetDrawLayer(1);
			
			image = new ImageWidget(Vector2.Zero, new(800, 800), "texture");
			
			image.SetDrawLayer(0);

			text = new TextWidget(new(100, 100), "hello", 50, null, Color.BLACK);
			UIManager.Add(text);

			dino = new AnimatedGameObject(new(100, 300), "run", 2, 0.1f, 1);
			GameObjectManager.Add(dino);

			testdinomulti = new()
			dino.AddSprite("run", new(new(500, 300), "run", 2, 0.1f, 1));
			dino.AddSprite("idle", new(new(500, 300), "idle", 2, 0.1f, 1));
			GameObjectManager.Add(dino.CallSprite("run"));

			
			
			

			dinoButStill = new(new(100, 400), "run", 1);
			GameObjectManager.Add(dinoButStill);
			
			buttonWidget.AddListener(OnClickButton);
			buttonWidget.AddListener(() =>
			{
				if(counter % 2 == 0)
					UIManager.Add(image);
				else 
					UIManager.Remove(image);

				counter++;
				Console.WriteLine("WEEEWOOOO!");
				
				/*buttonWidget.Interactable = false;*/
			});
		}

		public override void Draw()
		{
			Raylib.DrawFPS(0, 0);
		}
		public override void Unload()
		{
			
		}

		public override void Update(float _deltaTime)
		{
			Raylib.DrawText(_deltaTime.ToString(), 0, 20, 30, Color.BEIGE);
			
			if(Raylib.IsKeyPressed(KeyboardKey.KEY_A))
			{
				GameObjectManager.Remove(dino.CallSprite("run"));
				GameObjectManager.Add(dino.CallSprite("idle"));
			}
			if(Raylib.IsKeyPressed(KeyboardKey.KEY_S))
			{
				GameObjectManager.Remove(dino.CallSprite("idle"));
				GameObjectManager.Add(dino.CallSprite("run"));
			}
			
		}
	}
}