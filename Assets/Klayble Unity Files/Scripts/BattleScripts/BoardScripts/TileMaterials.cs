using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoardSystem;

    /// <summary>
    /// TileMaterialManager is a utility static class meant to store all of the Materials for Tile Prefabs, based on the
    /// Tile enumerated type in the TileController.
    /// 
    /// I'd like to have palettes
    /// </summary>
    public static class TileMaterialManager
    {
        [SerializeField] // TODO: Does this need to be stabilized?
        private static List<Material> m_SampleMatPalette;
        public static List<Material> SampleMatPalette { get => m_SampleMatPalette; private set => m_SampleMatPalette = value; }

        private static Dictionary<Tile, Material> m_TileMaterials = new Dictionary<Tile, Material>();



        /// <summary>
        /// Initializes m_TileMaterials with the appropriate data.
        /// </summary>
        static TileMaterialManager()
        {
            // Initialize m_TileMaterials
            m_TileMaterials.Add(Tile.Normal, null);
            m_TileMaterials.Add(Tile.Lava, null);
            m_TileMaterials.Add(Tile.Poison, null);
            m_TileMaterials.Add(Tile.Water, null);
        }

        public static Material UpdateMaterial(Tile tile)
        {
            if(m_TileMaterials.ContainsKey(tile))
            {
                return m_TileMaterials[tile];
            } else
            {
                Debug.Log("No such material for type " + tile.ToString() + "!");
                return null;
            }
        }
    }
