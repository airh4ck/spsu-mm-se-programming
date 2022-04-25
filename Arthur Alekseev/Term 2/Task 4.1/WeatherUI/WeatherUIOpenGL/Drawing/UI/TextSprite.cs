﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WeatherUIOpenGL.Drawing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing.Text;
using OpenTK.Graphics.OpenGL4;

namespace WeatherUIOpenGL.Drawing.UI
{
	public class TextSprite : IRenderable
	{
		// Parameters for text texture
		private Bitmap bmp;
		private int width = 480;
		private int height = 50;

		// Text opacity
		public float textOpacity = 1f;

		// Renderables
		private Sprite sprite;

        public TextSprite(float[] coordinates, string text)
		{
			createTextTexture(text);

			Texture texture = Texture.LoadFromBitmap(bmp);
			Shader shader = Shader.GenBasicShader();

			sprite = new Sprite(coordinates, shader, texture);
		}

		private void createTextTexture(string text)
		{
			PrivateFontCollection collection = new PrivateFontCollection();
			collection.AddFontFile(@"Files/fontb.ttf");
			FontFamily fontFamily = new FontFamily("Open Sans Semibold", collection);

			Font font = new Font(fontFamily, 28);

			bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			var gfx = Graphics.FromImage(bmp);
			var brush = Brushes.White;

			gfx.TextRenderingHint = TextRenderingHint.AntiAlias;
			gfx.DrawString(text, font, brush, new PointF(0, 0));
		}

		public void Render()
		{
			updateUniforms();

			sprite.Render();
		}

		private void updateUniforms()
		{
			sprite.shader.Use();
			var location = sprite.shader.GetUniformLocation("opacity");
			GL.Uniform1(location, 1f - textOpacity);
		}

		public void Load()
		{
			sprite.Load();
		}
	}
}
