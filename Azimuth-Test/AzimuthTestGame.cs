using Azimuth;
using Azimuth.GameObjects;
using Azimuth.UI;

using MathLib;

using Raylib_cs;

using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{

		private ImageWidget image;
		private ButtonWidget buttonWidget;
		private TextWidget text;
		private AnimatedGameObject dino;

		
		
		private void OnClickButton()
		{
			Console.WriteLine("Hello WOrld!");
		}
		public override void Load()
		{
			int counter = 0;
			
			buttonWidget = new ButtonWidget(new Vec2(300, 300), new Vec2(150,75),"hello" , new ButtonWidget.RenderSettings(50, null, Color.WHITE));
			UIManager.Add(buttonWidget);
			buttonWidget.SetDrawLayer(1);
			
			image = new ImageWidget(Vec2.zero, new(800, 800), "texture");
			
			image.SetDrawLayer(0);

			text = new TextWidget(new(100, 100), "hello", 50, null, Color.BLACK);
			UIManager.Add(text);

			
			
			dino = new AnimatedGameObject(new(0, 60, 176, 94), new(100, 300), "Dino", 2, 0.1f, 1);
			GameObjectManager.Add(dino);
			
			dino.AddRectangle("run", new(0, 60, 176, 94));
			dino.AddRectangle("idle", new Rectangle(0, 154, 176, 94));
			dino.AddRectangle("duck", new Rectangle(0, 0, 236, 60));

			
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
				dino.ChangeAnimation(dino.CallRectangle("run"), null, null);
			
			if(Raylib.IsKeyPressed(KeyboardKey.KEY_S))
				dino.ChangeAnimation(dino.CallRectangle("duck"), null, null);
			
			if(Raylib.IsKeyPressed(KeyboardKey.KEY_D))
				dino.ChangeAnimation(dino.CallRectangle("idle"), null, null);

		}
	}
}