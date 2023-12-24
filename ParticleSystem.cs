using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ParticleEngine
{
    public class ParticleSystem
    {
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> particles;
        private List<Texture2D> textures;
        private int amount { get; set; }

        public ParticleSystem(int amount, Vector2 emitterLocation, List<Texture2D> textures)
        {
            random = new Random();
            EmitterLocation = emitterLocation;
            this.textures = textures;
            particles = new List<Particle>();
            this.amount = amount;
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 Position = EmitterLocation;
            Vector2 velocity = new Vector2(
                2f * (float)(random.NextDouble() * 2 - 1),
                1f * (float)(random.NextDouble() * 2 - 1) - 8f);
            velocity *= 2f;
            float angle = 0;
            float angularVelocity = 0.1f * 1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(
                (float)random.NextDouble() * 0.35f,
                (float)random.NextDouble() * 0.65f,
                (float)random.NextDouble());
            Color secondColor = new Color(
                 color.G,
                 color.R,
                 color.B);
            float scale = (0.25f * random.Next(2));
            int lifetime = 40 + random.Next(40);
            return new Particle(texture, Position, velocity, angle, angularVelocity, color, scale, lifetime, 1f, 1f, secondColor);
        }

        public void Update()
        {
            for(int i = 0; i < amount; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for(int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].Lifetime <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for(int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spritebatch);
            }
            spritebatch.End();
        }
    }
}
