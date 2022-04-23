@echo off
echo Welcome to OpenFK OCX fetcher!
echo Written by GittyMac
echo ------------------------------
for /f "delims=" %%a in ('powershell $PSVersionTable.PSVersion.Major') do set "var=%%a"
if %var% lss 3 @echo Your Powershell version is too old to fetch the OCX. Update Powershell to version 3 or higher. && pause && exit
echo Downloading data...
mkdir tempdl
cd tempdl
powershell -Command "Invoke-WebRequest http://download.windowsupdate.com/c/msdownload/update/software/secu/2019/06/windows10.0-kb4503308-x64_b6478017674279c8ba4f06e60fc3bab04ed7ae02.msu -OutFile update.msu"
echo Extracting MSU...
expand -f:* update.msu ./ 
echo Extracting CAB...
expand Windows10.0-KB4503308-x64.cab -F:* ./
echo Fetching OCX...
IF EXIST "%PROGRAMFILES(X86)%" (GOTO 64BIT) ELSE (GOTO 32BIT)

:64BIT
copy "%cd%\amd64_adobe-flash-for-windows_31bf3856ad364e35_10.0.18362.172_none_815470a5fb446c4e\flash.ocx" "..\Flash.ocx"
GOTO END

:32BIT
copy "%cd%\wow64_adobe-flash-for-windows_31bf3856ad364e35_10.0.18362.172_none_8ba91af82fa52e49\flash.ocx" "..\Flash.ocx"
GOTO END

:END
cd ..
rmdir /s /q tempdl
echo Your Flash.OCX is served!