using System.Xml.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace KenneySpritesheetImporter
{
    [ContentImporter(".xml", DisplayName = "XML Importer - Kenney", DefaultProcessor = "SpritesheetProcessor")]
    public class SpritesheetImporter : ContentImporter<XElement>
    {
        public override XElement Import(string filename, ContentImporterContext context)
        {   
            return XElement.Load(filename);
        }
    }
}
