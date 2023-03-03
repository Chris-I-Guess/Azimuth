using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public class TextWidget : Widget
	{
		private string text;
		
		private string? fontId;
		private Font font;
		
		private Vector2 textSize;
		private Color textColor;
		
		private int fontSize;
		private float fontSpacing = 1f;
		
		public TextWidget(Vector2 _position, string _text , int _fontSize, string? _fontId, Color _textColor) : base(_position, Vector2.Zero)
		{
			text = _text;
			fontSize = _fontSize;
			fontId = _fontId;
			textColor = _textColor;
			
			
			font = string.IsNullOrEmpty(fontId) ? Raylib.GetFontDefault() : Assets.Find<Font>("Fonts/" + fontId);
			textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing);
			size = textSize;
		}
		
		public override void Draw()
		{
			Vector2 textPosition = new(position.X, position.Y);
			
			Raylib.DrawTextPro(font, text, textPosition, new Vector2 (textSize.X * 0.5f, textSize.Y * 0.5f), 0f, fontSize, fontSpacing, textColor);
		}
	}
}