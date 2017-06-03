using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace topdown
{
    class TileRect
    {
        public int tileId { get; set; }
        public Rectangle rectangle { get; set; }

        public TileRect(int tileId, Rectangle rectangle)
        {
            this.tileId = tileId;
            this.rectangle = rectangle;
        }
    }

    class Map
    {
        static int width, height, heightDiff;
        static int screenWidthCap, screenHeightCap;
        static int tileWidth, tileHeight, mapWidth, mapHeight;
        static TmxLayer background, wall, collision;
        int tiles;
        Texture2D textureTileset;
        TmxTileset tmxTileset;
        static Map inst;
        private int[] collisionTileIds;
        private int emptyTileId = 0;

        public Map(int tiles)
        {
            this.tiles = tiles;
            inst = this;
        }

        public void LoadContent()
        {
            /*
            width = GraphicsDevice.Viewport.Bounds.Width;
            height = GraphicsDevice.Viewport.Bounds.Height;
            screenWidthCap = (width / 2) + 20;
            screenHeightCap = (height / 2) + 20;
            TmxMap map = new TmxMap("Content/testmap3.tmx");
            var version = map.Version;
            tmxTileset = map.Tilesets["KITileset"];
            background = map.Layers[0];
            wall = map.Layers[1];
            collision = map.Layers[2];
            tileWidth = tmxTileset.TileWidth;
            tileHeight = tmxTileset.TileHeight;
            mapWidth = map.Width;
            mapHeight = map.Height;

            textureTileset = Content.Load<Texture2D>(map.Tilesets[0].Name);
            heightDiff = (map.Height * tileHeight) - height;

            player.position = new Vector2((int)map.ObjectGroups[0].Objects[0].X, (int)map.ObjectGroups[0].Objects[0].Y - heightDiff);
            player.setMap(this);
            */
        }



    }
}
