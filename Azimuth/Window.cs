using Raylib_cs;

namespace Azimuth
{
	public sealed class Window
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		public string Title { get; }

		public int fps { get; }
		public Color ClearColor { get; }

		public Window()
		{
			Width = Config.Get<int>("Window", "width");
			Height = Config.Get<int>("Window", "height");
			Title = Config.Get<string>("Application", "name")!;
			fps = Config.Get<int>("Window", "fps");
			ClearColor = Config.Get<Color>("Window", "clearColor");
			
			Raylib.SetExitKey((KeyboardKey)Config.Get<int>("Application", "quitKey"));
			
			if(Config.Get<bool>("Window", "resizableWindow"))
				Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);

			
		}

		public void Open()
		{
			Raylib.InitWindow(Width, Height, Title);
			Raylib.SetTargetFPS(fps);
		}

		public void Clear()
		{
			Raylib.ClearBackground(ClearColor);

			Width = Raylib.GetScreenWidth();
			Height = Raylib.GetScreenHeight();
			
			/*Raylib.ToggleFullscreen();
			Raylib.SetWindowSize(Raylib.GetMonitorWidth(), Raylib.GetMonitorHeight());*/
		}	
		
		public void Close()
		{
			Raylib.CloseWindow();
		}
	}
}