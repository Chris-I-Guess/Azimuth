using MathLib;

using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public class TextWidget : Widget
	{
		private string text;
		
		private string? fontId;
		private Font font;
		
		private Vec2 textSize;
		private Color textColor;
		
		private int fontSize;
		private float fontSpacing = 1f;
		
		public TextWidget(Vec2 _position, string _text , int _fontSize, string? _fontId, Color _textColor) : base(_position, Vec2.zero)
		{
			text = _text;
			fontSize = _fontSize;
			fontId = _fontId;
			textColor = _textColor;
			
			
			font = string.IsNullOrEmpty(fontId) ? Raylib.GetFontDefault() : Assets.Find<Font>("Fonts/" + fontId);
			textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing);
			size = textSize;
		}
		public void UpdateText(string _text) => text = _text;
		
		public override void Draw()
		{
			Vec2 textPosition = new Vec2(position.x, position.y);
			
			Raylib.DrawTextPro(font, text, textPosition, new Vec2 (textSize.x * 0.5f, textSize.y * 0.5f), 0f, fontSize, fontSpacing, textColor);
		}
	}
}