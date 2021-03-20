@echo off
echo OpenFK Update in progress...
taskkill /f /im OpenFK.exe
xcopy /s /y "%cd%\tmpdl" "%cd%"
rmdir /s /Q "%cd%\tmpdl"
del /q "%cd%\tmpdl.zip"
start "" "%cd%\OpenFK.exe"