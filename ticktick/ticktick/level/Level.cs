using System;
using Microsoft.Xna.Framework;

partial class Level : GameObjectList
{
    protected Button quitButton;

    public Level(int levelIndex)
    {
        GameObjectList backgrounds = new GameObjectList(0, "backgrounds");
        SpriteGameObject background_main = new SpriteGameObject("Backgrounds/spr_sky");
        background_main.Position = new Vector2(0, GameEnvironment.Screen.Y - background_main.Height);
        backgrounds.Add(background_main);

        for (int i = 0; i < 5; i++)
        {
            SpriteGameObject mountain = new SpriteGameObject("Backgrounds/spr_mountain_" + (GameEnvironment.Random.Next(2) + 1), 1);
            mountain.Position = new Vector2((float)GameEnvironment.Random.NextDouble() * GameEnvironment.Screen.X - mountain.Width / 2, GameEnvironment.Screen.Y - mountain.Height);
            backgrounds.Add(mountain);
        }
        
        this.Add(backgrounds);

        quitButton = new Button("Sprites/spr_button_quit", 100);
        quitButton.Position = new Vector2(GameEnvironment.Screen.X - quitButton.Width - 10, 10);
        this.Add(quitButton);

        this.LoadTiles("Content/Levels/" + levelIndex + ".txt");
    }
}

