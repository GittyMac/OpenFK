<img src="https://github.com/GittyMac/OpenFK/blob/gh-pages/logo.png?raw=true" alt="OpenFK Logo" width="256" />

# OpenFK
#### An open source replacement for the U.B. Funkeys executable.

OpenFK aims to enable the game to be played without having Adobe Flash Player installed, making it easier to play on modern operating systems.

### Installing OpenFK
To install OpenFK, you need an existing installation of the U.B. Funkeys game along with .NET Framework 4.5. After downloading the ZIP file, simply extract the contents into the RadicaGame folder of your U.B. Funkeys installation directory. When the extraction process has finished, simply run OpenFK instead of UBFunkeys.exe to play. 

### Compatiblity
OpenFK supports all versions of U.B. Funkeys. Versions that utilize RDFv2 are fully supported as a drop-in replacement. Older versions that utilize the original RDFv1 format require a manual conversion of the RDF files. To achieve this, run the original UBFunkeys.exe with the -debug argument. This will create a log file that includes the RDF data of all the files loaded inside of it. Very old versions of the game also use a different way of creating users, which OpenFK tries to implement. This however can cuase issues, which may require manual intervention.

### Linux/Mac Port
OpenFK is heavily tied to ActiveX due to it having one of the only working versions of Adobe Flash Player that has support for isolating the plugin, processing FSCommands, and the SetVar command. This means that OpenFK will only be made for Windows, however the x86 version works flawlessly on Wine with the Adobe Flash Player 10 OCX. 

### Issues beware!
OpenFK has been made to closely mimic the original UBFunkeys.exe, reaching near feature parity since v1.5. However, due to the way OpenFK was made, it can still have issues that only occur with OpenFK. These primarily occur in areas that have not been fully implemented and tested. These include the Paradox Green minigames and network connectivity. If you can find replicable errors with OpenFK, make sure to place an issue.

### Building OpenFK
You can build OpenFK with anything that can build dotNET 4.5 projects, like Visual Studio. You also need to have the ActiveX version of Adobe Flash Player installed to be able to use the 'Shockwave Flash Object' COM component.
