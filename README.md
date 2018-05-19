# KenneySpritesheetImporter
Monogame content importer for Kenney's spritesheet XML.

Reads the XML files provided with the spritesheets in the various 2D packs, which are incompatible with default XML importer.

## How to use
Add a reference to the DLL in the Content Pipeline, then load the XML as any other asset.
```csharp
Dictionary<string, Rectangle> data = Content.Load<Dictionary<string, Rectangle>>("spritesheet_data");
```

Content pipeline parameters::
* 'AddMainImage' - adds a name of the spritesheet atlas, using an empty Rectangle for a value. 
* 'KeepTextureExtension' - retains the extensions (usually .png) of all images mentioned in the file.

## Special thanks
* [Kenney](http://kenney.nl/assets) - for making free assets
* Monogame team
