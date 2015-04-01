using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

partial class Level : GameObjectList
{
    public void LoadTiles(string path)
    {
        int width;
        List<string> textlines = new List<string>();
        StreamReader fileReader = new StreamReader(path);
        string line = fileReader.ReadLine();
        width = line.Length;
        while (line != null)
        {
            textlines.Add(line);
            line = fileReader.ReadLine();
        }
        TileField tiles = new TileField(textlines.Count - 1, width, 1, "tiles");

        this.Add(tiles);
        tiles.CellWidth = 72;
        tiles.CellHeight = 55;
        for (int x = 0; x < width; ++x)
            for (int y = 0; y < textlines.Count - 1; ++y)
            {
                Tile t = LoadTile(textlines[y][x], x, y);
                tiles.Add(t, x, y);
                this.Add(new GameObjectList(1,"waterdrops"));
                this.Add(new GameObjectList(1,"enemies"));
            }
    }

    private Tile LoadTile(char tileType, int x, int y)
    {
        switch (tileType)
        {
            case '.':
                return new Tile();
            case '-':
                return LoadBasicTile("spr_platform", TileType.Platform);
            case 'X':
                return LoadEndTile(x, y);
            case '1':
                return LoadStartTile(x, y);
            case '#':
                return LoadBasicTile("spr_wall", TileType.Normal);
            case 'W':
                return LoadWaterTile(x, y);
            case 'R':
                return LoadRocketTile(true, new Vector2(x, y));
            default:
                return new Tile("");
        }
    }

    private Tile LoadBasicTile(string name, TileType tileType, bool hot = false, bool ice = false)
    {
        Tile t = new Tile("Tiles/" + name, tileType);
        t.Hot = hot;
        t.Ice = ice;
        return t;
    }

    private Tile LoadStartTile(int x, int y)
    {
        TileField tiles = this.Find("tiles") as TileField;
        Vector2 startPosition = new Vector2(((float)x + 0.5f) * tiles.CellWidth, (y + 1) * tiles.CellHeight);
        Player player = new Player(startPosition);
        this.Add(player);
        return new Tile("", TileType.Background);
    }

    private Tile LoadEndTile(int x, int y)
    {
        TileField tiles = this.Find("tiles") as TileField;
        SpriteGameObject exitObj = new SpriteGameObject("Sprites/spr_goal", 1, "exit");
        exitObj.Position = new Vector2(x * tiles.CellWidth, (y + 1) * tiles.CellHeight);
        exitObj.Origin = new Vector2(0, exitObj.Height);
        this.Add(exitObj);
        return new Tile();
    }

    private Tile LoadWaterTile(int x, int y)
    {
        GameObjectList waterdrops = this.Find("waterdrops") as GameObjectList;
        TileField tiles = this.Find("tiles") as TileField;
        WaterDrop w = new WaterDrop();
        w.Origin = w.Center;
        w.Position = new Vector2(x * tiles.CellWidth, y * tiles.CellHeight - 10);
        w.Position += new Vector2(tiles.CellWidth, tiles.CellHeight) / 2;
        waterdrops.Add(w);
        return new Tile();
    }

    private Tile LoadRocketTile(bool moveToLeft, Vector2 startposition)
    {
        GameObjectList enemies = this.Find("enemies") as GameObjectList;
        TileField tiles = this.Find("tiles") as TileField;
        Rocket r = new Rocket(moveToLeft, new Vector2(startposition.X * tiles.CellWidth, startposition.Y * tiles.CellHeight - 10) + new Vector2(tiles.CellWidth, tiles.CellHeight) / 2);
        r.Origin = r.Center;
        enemies.Add(r);
        return new Tile();
    }
}