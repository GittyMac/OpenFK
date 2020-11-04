# OpenFK
#### An open source replacement for the U.B. Funkeys executable.

OpenFK adds new features while doing the same functions as the executable.

### What does OpenFK do currently?
| Functional  | Broken  |
| ------------ | ------------ |
| File loading via XMLs  | Checking updates |
| Saving files  | ActionScript 3 Elements |
| Fullscreen and Windowed mode | USB connectivity |
| Basic online functionality | |
| Mod support | |
| Closing the game | |
| Native RDF loading | |

### Installing OpenFK

OpenFK requires some manual work to set it up fully. 

First, convert the RDF files in data/system and your user profile in data/YOURUSERNAME to an XML, you can do this in many ways, like using the debug logs or using an RDF converter utility. 

You will also need to find the Flash.ocx file, it is usually found in the `C:\Windows\System32\Macromed\Flash\` directory. Put the Flash.ocx file with your OpenFK.exe file.

Be sure to run the 'Configure OpenFK.bat' file to choose from some choices!

### Building OpenFK
You can build OpenFK with anything that can build dotNET 4.5 projects, like Visual Studio. You also need to have Flash installed to be able to use the 'Shockwave Flash Object' COM component.
