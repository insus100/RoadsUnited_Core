﻿using ColossalFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace RoadsUnited_Core
{
    public class Configuration
    {
        public bool create_vanilla_dictionary = true;

        public bool use_custom_textures = true;
        public bool use_custom_colors = true;
        public bool disable_optional_arrow_lfr = false;
        public bool disable_optional_arrow_lr = false;


        public int selected_pack = 0;

        public int basic_road_parking = 0;
        public int medium_road_parking = 0;
        public int medium_road_grass_parking = 0;
        public int medium_road_trees_parking = 0;
        public int medium_road_bus_parking = 0;
        public int large_road_parking = 0;
        public int large_road_bus_parking = 0;
        public int large_oneway_parking = 0;

        public float ToolbarButtonX;
        public float ToolbarButtonY;


        public float small_road_brightness = 0.4f;

        public float small_road_decoration = 0.4f;

        public float medium_road_brightness = 0.4f;

        public float medium_road_decoration_brightness = 0.4f;

        public float large_road_brightness = 0.4f;

        public float large_road_decoration_brightness = 0.4f;

        public float highway_brightness = 0.4f;

        public float highway_national_brightness = 0.4f;

        public bool ShowToolbarButton = true;
        public bool FixateToolbarButton = false;

        public string texturePackPath = "None";

        public void OnPreSerialize()
        {
        }

        public void OnPostDeserialize()
        {
        }

        public static void Serialize(string filename, Configuration config)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                config.OnPreSerialize();
                xmlSerializer.Serialize(streamWriter, config);
            }
        }

        public static Configuration Deserialize(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
            Configuration result;
            try
            {
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    Configuration configuration = (Configuration)xmlSerializer.Deserialize(streamReader);
                    configuration.OnPostDeserialize();
                    result = configuration;
                    return result;
                }
            }
            catch
            {
            }
            result = null;
            return result;
        }
    }

}
