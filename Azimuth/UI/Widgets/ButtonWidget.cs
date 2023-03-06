using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public class ButtonWidget : InteractableWidget
	{
		public delegate void OnClickEvent();
		public class RenderSettings
		{
			public RenderSettings( int _fontSize, string? _fontId, Color _textColor) 
			{
				fontSize = _fontSize;
				fontId = _fontId;
				textColor = _textColor;
			}

			public ColorBlock colors = new ColorBlock()
			{
				disabled = new Color(255, 255, 255, 128),
				hovered = Color.LIGHTGRAY,
				normal = Color.DARKGRAY,
				selected = Color.BLACK
			};
			
			public int fontSize;
			public string? fontId;
			public Color textColor;
			public float roundedness = 0.1f;
			public float fontSpacing = 1f;
		}

		private OnClickEvent? onClick;
		
		private readonly float roundedness;

		private readonly string text;
		private readonly int fontSize;
		private readonly float fontSpacing;

		private readonly Font font;
		private readonly Color textColor;
		private readonly Vector2 textSize;

		public ButtonWidget(Vector2 _position, Vector2 _size, string _text, RenderSettings _settings) : base(_position, _size, _settings.colors)
		{
			roundedness = _settings.roundedness;

			text = _text;
			fontSize = _settings.fontSize;
			fontSpacing = _settings.fontSpacing;

			font = string.IsNullOrEmpty(_settings.fontId) ? Raylib.GetFontDefault() : Assets.Find<Font>("Fonts/" + _settings.fontId);
			textColor = _settings.textColor;
			textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing);
		}

		public void AddListener(OnClickEvent _event)
		{
			if(onClick == null)
			{
				onClick = _event;
			}
			else
			{
				onClick += _event;
			}
		}
		
		public void RemoveListener(OnClickEvent _event)
		{
			if(onClick != null)
			{
				onClick -= _event;
			}
		}
		
		public override void Draw()
		{
			Raylib.DrawRectangleRounded(Bounds, roundedness, 5, ColorFromState());
			
			Vector2 textPosition = new(position.X + (size.X * 0.5f), position.Y + (size.Y * 0.5f));
			
			Raylib.DrawTextPro(font, text, textPosition, new Vector2 (textSize.X * 0.5f, textSize.Y * 0.5f), 0f, fontSize, fontSpacing, textColor);
		}

		protected override void OnStateChange(InteractionState _state, InteractionState _oldState)
		{
			if(_state != InteractionState.Selected && _oldState == InteractionState.Selected)
			{
				// The button is no longer being clicked, so do the event.
				onClick?.Invoke();
			}
		}
	}
}