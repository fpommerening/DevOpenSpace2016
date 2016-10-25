cd C:\Projects\DevOpenSpace2016\Samples\Logging\src\Caller
dotnet publish -c Release -o c:\temp\devSpace\logging-caller
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a logging-caller.7z c:\temp\devSpace\logging-caller
cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\logging-caller\app
copy c:\temp\devSpace\logging-caller.7z
cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\logging-caller
rem docker build -t fpommerening/devopenspace2016:logging-caller .


cd C:\Projects\DevOpenSpace2016\Samples\Logging\src\ConsoleListener
dotnet publish -c Release -o c:\temp\devSpace\logging-console
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a logging-console.7z c:\temp\devSpace\logging-console
cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\logging-console\app
copy c:\temp\devSpace\logging-console.7z
cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\logging-console
rem docker build -t fpommerening/devopenspace2016:logging-console .


cd C:\Projects\DevOpenSpace2016\Samples\Logging\src\WebLogger
dotnet publish -c Release -o c:\temp\devSpace\logging-web
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a logging-web.7z c:\temp\devSpace\logging-web
cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\logging-web\app
copy c:\temp\devSpace\logging-web.7z
cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\logging-web
rem docker build -t fpommerening/devopenspace2016:logging-web .


cd C:\Projects\DevOpenSpace2016\Samples\Logging\dockerfiles\x86_64\weblogger