using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D[] runningTextures;
    Texture2D[] enemyTextures;
    int counter;
    int activeFrame;
    int enemyPosY = 310;
    int enemyPosX = 200;
    int PlayerX = 400;
    int PlayerY = 300;
    Texture2D background;
    Texture2D spike;

    private SpriteFont _font;

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
        background = Content.Load<Texture2D>("background");

        runningTextures = new Texture2D[4];
        enemyTextures = new Texture2D[4];

        runningTextures[0] = Content.Load<Texture2D>("frame_0");
        runningTextures[1] = Content.Load<Texture2D>("frame_1");
        runningTextures[2] = Content.Load<Texture2D>("frame_2");
        runningTextures[3] = Content.Load<Texture2D>("frame_3");
        enemyTextures[0] = Content.Load<Texture2D>("enemy");
        enemyTextures[1] = Content.Load<Texture2D>("enemy(1)");
        enemyTextures[2] = Content.Load<Texture2D>("enemy(2)");
        enemyTextures[3] = Content.Load<Texture2D>("enemy(3)");
        spike = Content.Load<Texture2D>("spike");
        _font = Content.Load<SpriteFont>("Font");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // TODO: Add your update logic here

        counter++;
        if (counter < 29)
        {
            counter = 0;
            activeFrame++;
            if (activeFrame > runningTextures.Length - 1)
            {
                activeFrame = 0;
            }

        }
        enemyPosX += 1;
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            PlayerX -= 5;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            PlayerX += 5;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            PlayerY -= 5;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            PlayerY += 5;
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here 
        _spriteBatch.Begin();
        _spriteBatch.Draw(background, GraphicsDevice.Viewport.Bounds, Color.White);
        _spriteBatch.Draw(enemyTextures[activeFrame], new Rectangle(enemyPosX, enemyPosY, 64, 48), Color.White);
        _spriteBatch.Draw(spike, new Rectangle(300, 310, 64, 33), Color.White);
        _spriteBatch.Draw(runningTextures[activeFrame], new Rectangle(PlayerX, PlayerY, 64, 62), Color.White);
        _spriteBatch.DrawString(_font,"Hello World!", Vector2.Zero, Color.Red);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
