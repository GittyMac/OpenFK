# OpenFK
##### An open source replacement for the U.B. Funkeys executable.

OpenFK adds new features while doing the same functions as the executable.

### What does OpenFK do currently?
| Functional  | Broken  |
| ------------ | ------------ |
| File loading via XMLs  | Native RDF loading  |
| Saving files  | Checking updates  |
| Fullscreen and Windowed mode |  ActionScript 3 Elements |
| Basic online functionality | USB connectivity |
| Mod support |
| Closing the game |

###Installing OpenFK
OpenFK requires some manual work to set it up fully. 

First, convert the RDF files in data/system and your user profile in data/YOURUSERNAME to an XML, you can do this in many ways, like using the debug logs or using an RDF converter utility. 

You will also need to find the Flash.ocx file, it is usually found in the `C:\Windows\System32\Macromed\Flash\` directory. Put the Flash.ocx file with your OpenFK.exe file.

Be sure to check the OpenFK.exe.config file for options you can set with it. Put OpenFK.exe and its required files in the RadicaGame folder.

###Building OpenFK
You can build OpenFK with anything that can build dotNET 4.5 projects, like Visual Studio.