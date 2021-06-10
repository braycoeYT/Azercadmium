using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Azercadmium.Textures;

namespace Azercadmium.Effects
{
    public class VertexStrip
    {
        public delegate Color GetStripColor(float progress);

        public delegate Vector2 GetStripWidth(float progress);

		public Effect effect = Azercadmium.Instance.VertexShader;
		
		public string pass;

		public float strenght; // mispelt lol

		public Texture2D texture;

		public VertexStrip(string Pass = "Basic", Texture2D texture = null, float strenght = 1f)
		{
		    this.pass = Pass;
			this.strenght = strenght;
			if (pass == "Image" || pass == "Image1" || pass == "ImageFaded")
			{
				if (texture != null)
                {
					this.texture = texture;
				}
				else
				{
					this.texture = TextureContainer.trailTextures[0];
				}
			}
		}

        public struct VertexInfo : IVertexType
        {
            public Vector2 Position;
			public Color Color;
			public Vector2 TexCoord;
			private static VertexDeclaration _vertexDeclaration = new VertexDeclaration(new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0), new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0), new VertexElement(12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0));
			public VertexDeclaration VertexDeclaration => _vertexDeclaration;
			public VertexInfo(Vector2 position, Color color, Vector2 texCoord)
			{
				Position = position;
				Color = color;
				TexCoord = texCoord;
			}
        }

        private VertexInfo[] _vertices = new VertexInfo[1];

		private int _vertexAmountCurrentlyMaintained;

		private short[] _indices = new short[1];

		private int _indicesAmountCurrentlyMaintained;

        public void PrepareStrip(Vector2[] oldPos, float[] oldRot, GetStripWidth stripWidth, GetStripColor stripColor, Vector2 offset = default(Vector2), int? expectedVertexPairsAmount = null, bool includeBacksides = false)
        {
            int lenght = oldPos.Length;
            int vertexLenght = _vertexAmountCurrentlyMaintained = lenght * 2;
            if (_vertices.Length < vertexLenght)
			{
				Array.Resize(ref _vertices, vertexLenght);
			}
            int expectedAmount = expectedVertexPairsAmount.HasValue ? expectedVertexPairsAmount.Value : lenght;
            for(int i = 0; i < lenght; i++)
            {
                if (oldPos[i] == Vector2.Zero)
                {
                    lenght = i - 1;
                    expectedVertexPairsAmount = lenght * 2;
                }
                Vector2 pos = oldPos[i] + offset;
                float rot = MathHelper.WrapAngle(oldRot[i]);
                float progress = (float)i / (float)(expectedAmount - 1);
                AddVertex(stripColor, stripWidth, pos, rot, i * 2, progress);
            }
            PrepareIndices(lenght, includeBacksides);
        }

        private void AddVertex(GetStripColor stripColor, GetStripWidth stripWidth, Vector2 pos, float rot, int index, float progress)
		{
			while (index + 1 >= _vertices.Length)
			{
				Array.Resize(ref _vertices, _vertices.Length * 2);
			}
			Color color = stripColor(progress);
			Vector2 scaleFactor = stripWidth(progress);
			Vector2 value = MathHelper.WrapAngle(rot - (float)Math.PI / 2f).ToRotationVector2() * scaleFactor;
			_vertices[index].Position = pos + value;
			_vertices[index + 1].Position = pos - value;
			_vertices[index].TexCoord = new Vector2(progress, 1f);
			_vertices[index + 1].TexCoord = new Vector2(progress, 0f);
			_vertices[index].Color = color;
			_vertices[index + 1].Color = color;
		}
		
        // completely cloned cuz too lazy to revamp and idk wut its used for.
        private void PrepareIndices(int vertexPaidsAdded, bool includeBacksides)
		{
			int num = vertexPaidsAdded - 1;
			int num2 = 6 + includeBacksides.ToInt() * 6;
			int num3 = _indicesAmountCurrentlyMaintained = num * num2;
			if (_indices.Length < num3)
			{
				Array.Resize(ref _indices, num3);
			}
			for (short num4 = 0; num4 < num; num4 = (short)(num4 + 1))
			{
				short num5 = (short)(num4 * num2);
				int num6 = num4 * 2;
				_indices[num5] = (short)num6;
				_indices[num5 + 1] = (short)(num6 + 1);
				_indices[num5 + 2] = (short)(num6 + 2);
				_indices[num5 + 3] = (short)(num6 + 2);
				_indices[num5 + 4] = (short)(num6 + 1);
				_indices[num5 + 5] = (short)(num6 + 3);
				if (includeBacksides)
				{
					_indices[num5 + 6] = (short)(num6 + 2);
					_indices[num5 + 7] = (short)(num6 + 1);
					_indices[num5 + 8] = (short)num6;
					_indices[num5 + 9] = (short)(num6 + 2);
					_indices[num5 + 10] = (short)(num6 + 3);
					_indices[num5 + 11] = (short)(num6 + 1);
				}
			}
		}

		public Matrix WVP()
		{
			GraphicsDevice graphics = Main.graphics.GraphicsDevice;
			Vector2 zoom = Main.GameViewMatrix.Zoom;
			int width = graphics.Viewport.Width;
            int height = graphics.Viewport.Height;
            Matrix Zoom = Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.Up) * Matrix.CreateTranslation(width / 2, height / -2, 0) * Matrix.CreateRotationZ(MathHelper.Pi) * Matrix.CreateScale(zoom.X, zoom.Y, 1f);
			Matrix Projection = Matrix.CreateOrthographic(width, height, 0, 1000);
			return Zoom * Projection;
		}

        public void Draw()
		{
			if (_vertexAmountCurrentlyMaintained >= 3 && _indicesAmountCurrentlyMaintained >= 3)
			{
			    VertexBuffer buffer = new VertexBuffer(Main.graphics.GraphicsDevice, typeof(VertexInfo), _vertices.Length, BufferUsage.WriteOnly); //create a new buffer using Main.graphics.GraphicsDevice
				buffer.SetData(_vertices); //set the buffer's data to the generated vertices
				Main.graphics.GraphicsDevice.SetVertexBuffer(buffer); // create and set the graphics card's buffer to the new one with the generated data
                RasterizerState rasterizerState = new RasterizerState // create and set rasterizerState
				{
                    CullMode = CullMode.None
                }; 
                Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;
	    		effect.Parameters["WVP"].SetValue(value: WVP()); //set the correct matrix in the effect
				effect.Parameters["strength"].SetValue(strenght);
				if (pass == "Image" || pass == "Image1" || pass == "ImageFaded")
	    		    effect.Parameters["imageTexture"].SetValue(texture);
				effect.CurrentTechnique.Passes[pass].Apply(); // actually apply the shader lmao
				Main.graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, _vertices, 0, _vertexAmountCurrentlyMaintained, _indices, 0, _indicesAmountCurrentlyMaintained / 3); // draw normally after shader
				//Main.graphics.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, _vertexAmountCurrentlyMaintained); // use this one in case of shader error and stuff
			}
		}
    }
}