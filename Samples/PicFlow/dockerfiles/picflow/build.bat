cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\src\Authorization
dotnet publish -c Release -o c:\temp\devSpace\picflow-authorization
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a picflow-authorization.7z c:\temp\devSpace\picflow-authorization
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-authorization\app
copy c:\temp\devSpace\picflow-authorization.7z
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-authorization
docker build -t fpommerening/devopenspace2016:picflow-authorization .

cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\src\ImagePersistor
dotnet publish -c Release -o c:\temp\devSpace\picflow-persistor
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a picflow-persistor.7z c:\temp\devSpace\picflow-persistor
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-persistor\app
copy c:\temp\devSpace\picflow-persistor.7z
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-persistor
docker build -t fpommerening/devopenspace2016:picflow-persistor .

cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\src\ImageProcessor
dotnet publish -c Release -o c:\temp\devSpace\picflow-processor
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a picflow-processor.7z c:\temp\devSpace\picflow-processor
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-processor\app
copy c:\temp\devSpace\picflow-processor.7z
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-processor
docker build -t fpommerening/devopenspace2016:picflow-processor .

cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\src\Uploader
dotnet publish -c Release -o c:\temp\devSpace\picflow-uploader
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a picflow-uploader.7z c:\temp\devSpace\picflow-uploader
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-uploader\app
copy c:\temp\devSpace\picflow-uploader.7z
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-uploader
docker build -t fpommerening/devopenspace2016:picflow-uploader .

cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\src\WebApp
dotnet publish -c Release -o c:\temp\devSpace\picflow-webapp
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a picflow-webapp.7z c:\temp\devSpace\picflow-webapp
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-webapp\app
copy c:\temp\devSpace\picflow-webapp.7z
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-webapp
docker build -t fpommerening/devopenspace2016:picflow-webapp .

cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\src\ExternalApp
dotnet publish -c Release -o c:\temp\devSpace\picflow-extapp
cd c:\temp\devSpace
"c:\Program Files\7-Zip"\7z a picflow-extapp.7z c:\temp\devSpace\picflow-extapp
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-extapp\app
copy c:\temp\devSpace\picflow-extapp.7z
cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow-extapp
docker build -t fpommerening/devopenspace2016:picflow-extapp .

cd C:\Projects\DevOpenSpace2016\Samples\PicFlow\dockerfiles\picflow