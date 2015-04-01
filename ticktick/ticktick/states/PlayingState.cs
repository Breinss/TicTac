using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

class PlayingState : IGameLoopObject
{
    protected List<Level> levels;
    protected int currentLevelIndex;
    protected ContentManager Content;

    public PlayingState(ContentManager Content)
    {
        this.Content = Content;
        currentLevelIndex = 0;
        levels = new List<Level>();
        LoadLevels();
    }

    public Level CurrentLevel
    {
        get
        {
            return levels[currentLevelIndex];
        }
    }

    public int CurrentLevelIndex
    {
        get
        {
            return currentLevelIndex;
        }
        set
        {
            if (value >= 0 && value < levels.Count)
            {
                currentLevelIndex = value;
                CurrentLevel.Reset();
            }
        }
    }

    public List<Level> Levels
    {
        get
        {
            return levels;
        }
    }

    public virtual void HandleInput(InputHelper inputHelper)
    {
        CurrentLevel.HandleInput(inputHelper);
    }

    public virtual void Update(GameTime gameTime)
    {
        CurrentLevel.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        CurrentLevel.Draw(gameTime, spriteBatch);
    }

    public virtual void Reset()
    {
        CurrentLevel.Reset();
    }

    public void NextLevel()
    {
        CurrentLevel.Reset();
        if (currentLevelIndex >= levels.Count - 1)
            GameEnvironment.GameStateManager.SwitchTo("levelMenuState");
        else
        {
            CurrentLevelIndex++;
        }
    }

    public void LoadLevels()
    {
        for (int currLevel = 1; currLevel <= 1; currLevel++)
            levels.Add(new Level(currLevel));
    }
}