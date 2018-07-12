using Sharptile;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Sharptile.Unity
{
    public static class TilesetExtensions
    {
        static readonly Vector2 centerPivot = new Vector2(0.5f, 0.5f);

        public static SpriteMetaData[] GetSpritesheet(this Tileset tileset)
        {
            return Enumerable
                .Range(0, tileset.tilecount)
                .Select(id => {
                    var row = (id * tileset.tilewidth) / tileset.imagewidth;
                    var x = (id * tileset.tilewidth) % tileset.imagewidth;
                    var y = tileset.imageheight - (row * tileset.tileheight) - tileset.tileheight;

                    return new SpriteMetaData
                    {
                        alignment = (int)SpriteAlignment.Center,
                        name = tileset.name + "_" + id,
                        pivot = centerPivot,
                        rect = new Rect(x, y, tileset.tilewidth, tileset.tileheight),
                    };
                })
                .ToArray();
        }
    }
}
