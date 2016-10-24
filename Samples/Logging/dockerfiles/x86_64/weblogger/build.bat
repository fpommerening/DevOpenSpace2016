cd C:\Projects\DevOpenSpace2016\Samples\Logging\src\Caller
dotnet publish -c Release -o c:\temp\devSpace\logging-caller
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a logging-caller.7z c:\temp\devSpace\logging-caller

cd C:\Projects\DevOpenSpace2016\Samples\Logging\src\ConsoleListener
dotnet publish -c Release -o c:\temp\devSpace\logging-console
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a logging-console.7z c:\temp\devSpace\logging-console

cd C:\Projects\DevOpenSpace2016\Samples\Logging\src\WebLogger
dotnet publish -c Release -o c:\temp\devSpace\logging-web
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a logging-web.7z c:\temp\devSpace\logging-web