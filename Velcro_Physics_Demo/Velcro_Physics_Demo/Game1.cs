using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;

namespace Velcro_Physics_Demo
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private World World;//---the physics world

        private Player body1;//---our player class : inherites from Physics_Body
        private Physics_Body body2;//---base Physics_Body

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            World = new World(new Vector2(0, 10));//---initialize the world
            ConvertUnits.SetDisplayUnitToSimUnitRatio(100f);//---how many pixels equal 1 meter

            Texture2D texture = Content.Load<Texture2D>("Color");

            body1 = new Player(new Vector2(300, 100), Vector2.One, texture, World, BodyType.Dynamic);
            body2 = new Physics_Body(new Vector2(300, 400), Vector2.One, texture, World, BodyType.Static);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            World.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);//---update the physics world

           
            body1.Update();
            body2.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            body1.Draw(spriteBatch);
            body2.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
