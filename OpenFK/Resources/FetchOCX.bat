@echo off
echo Welcome to OpenFK OCX fetcher!
echo Written by GittyMac
echo ------------------------------
echo Downloading data...
mkdir tempdl
cd tempdl
powershell -Command "Invoke-WebRequest http://download.windowsupdate.com/d/msdownload/update/software/secu/2015/09/windows10.0-kb3087040-x64_ad0f78efb7b122fa9472dbb8050c4f358aceab49.msu -OutFile update.msu"
echo Extracting MSU...
expand -f:* update.msu ./ 
echo Extracting CAB...
expand Windows10.0-KB3087040-x64.cab -F:* ./
echo Fetching OCX...
IF EXIST "%PROGRAMFILES(X86)%" (GOTO 64BIT) ELSE (GOTO 32BIT)

:64BIT
copy "%cd%\amd64_adobe-flash-for-windows_31bf3856ad364e35_10.0.10240.16513_none_33a2f3db043a608d\flash.ocx" "..\Flash.ocx"
GOTO END

:32BIT
copy "%cd%\wow64_adobe-flash-for-windows_31bf3856ad364e35_10.0.10240.16513_none_3df79e2d389b2288\flash.ocx" "..\Flash.ocx"
GOTO END

:END
cd ..
rmdir /s /q tempdl
echo Your Flash.OCX is served!
