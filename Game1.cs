using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Textures;
using Nez.Systems;
using System.Diagnostics;

namespace GProg_NEZLibraryIntegration_JuliaC03052025
{
    public class Game1 : Nez.Core
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //LOAD content
            //spritebatch creation
            // challenge: use one Nez functionality
            var scene = Scene.CreateWithDefaultRenderer(Color.CornflowerBlue);

            var map = Content.LoadTiledMap("Content/TileMaps/test.tmx");
            var tiledEntity = scene.CreateEntity("tiled-map");
            tiledEntity.AddComponent(new TiledMapRenderer(map));

            Nez.Core.Scene = scene;

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Core.StartCoroutine(MyCoroutine());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        // Added functionality - Coroutine
        private System.Collections.Generic.IEnumerator<float> MyCoroutine()
        {
            while (true)
            {
                Debug.WriteLine("Coroutine running...");
                yield return 1.0f;  
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw tilemap
            base.Draw(gameTime);
        }
    }
}
