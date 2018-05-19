using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace KenneySpritesheetImporter
{
    [ContentProcessor(DisplayName = "Spritesheet Processor - Kenney")]
    public class SpritesheetProcessor : ContentProcessor<XElement, Dictionary<string, Rectangle>>
    {
        /// <summary>
        /// Adds image texture to the dictionary as the first key using empty rectangle as value.
        /// </summary>
        [DefaultValue(false)]
        public bool AddMainImage { get; set; }

        [DefaultValue(false)]
        public bool KeepTextureExtension { get; set; }

        public override Dictionary<string, Rectangle> Process(XElement input, ContentProcessorContext context)
        {
            var result = new Dictionary<string, Rectangle>();

            if (AddMainImage)
            {
                var image = input.Attribute("imagePath").Value;
                if (!KeepTextureExtension)
                    image = image.Remove(image.Length - 4);
                result.Add(input.Attribute("imagePath").Value, Rectangle.Empty);
            }

            foreach (var el in input.Descendants())
            {
                var name = el.Attribute("name").Value;
                var x = el.Attribute("x").Value;
                var y = el.Attribute("y").Value;
                var width = el.Attribute("width").Value;
                var height = el.Attribute("height").Value;

                if (!KeepTextureExtension)
                    name = name.Remove(name.Length - 4);

                if (!result.ContainsKey(name))
                    result.Add(name, new Rectangle(int.Parse(x), int.Parse(y), int.Parse(width), int.Parse(height)));
            }

            return result;
        }
    }
}