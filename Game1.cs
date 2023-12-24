using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ParticleEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D circle;
        Texture2D dirt;
        Texture2D fire;
        Texture2D flame;
        Texture2D light;
        Texture2D smoke;
        Texture2D spark;
        Texture2D star;

        ParticleSystem particleSystem;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            circle = Content.Load<Texture2D>("circle_01");

            dirt = Content.Load<Texture2D>("dirt_03");

            fire = Content.Load<Texture2D>("fire_01");

            flame = Content.Load<Texture2D>("flame_01");

            light = Content.Load<Texture2D>("light_01");

            smoke = Content.Load<Texture2D>("smoke_09");

            spark = Content.Load<Texture2D>("spark_01");

            star = Content.Load<Texture2D>("star_01");

            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(spark);

            textures.Add(fire);

            textures.Add(light);

            textures.Add(smoke);

            textures.Add(star);
            particleSystem = new ParticleSystem(25, new Vector2(400, 240), textures);

            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            particleSystem.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleSystem.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            particleSystem.Draw(_spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
