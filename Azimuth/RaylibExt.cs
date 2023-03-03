using System.Numerics;

namespace Raylib_cs
{
    public static class RaylibExt
    {
        public static void DrawTexture(Texture2D _texture, float _xPos, float _yPos, float _width, float _height, Color _color,
            float _rotation = 0.0f, float _xOrigin = 0.0f, float _yOrigin = 0.0f)
        {
            Rectangle dst = new Rectangle(_xPos, _yPos, _width, _height);
            Rectangle src = new Rectangle(0, 0, _texture.width, _texture.height);
            Vector2 origin = new Vector2(_xOrigin * _width, _yOrigin * _height);
            Raylib.DrawTexturePro(_texture, src, dst, origin, _rotation, _color);
        }
    }
}