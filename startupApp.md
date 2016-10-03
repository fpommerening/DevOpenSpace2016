# Startup-App

Im Workshop Microservices mit .NET und RabbitMQ wird Docker zur Bereitstellung der Umgebungen verwendet.
Um die Zeit effektiv nutzen zu können, testet bitte Dockerumgebung mit der Startup-App vorher.

1) Git-Repo <a href="https://github.com/fpommerening/DevOpenSpace2016.git">DevOpenSpace2016</a> klonen 

2) Docker-Console öffnen und 
    a) Docker for Windows: Powershell starten
    b) Docker-Toolbox

3) Im geklonten Repo in den Ordner dockerfiles/StartupApp wechseln

4) Anwendung per Docker-Compose aktualisieren / starten 

	docker-compose pull

<b> WICHTIG: im Zuge des Starts werden alle notwendigen Dockerimages für den Workshop heruntergeladen. Dies umfallt etwa 4 GB und kann abhängig von Internetgeschwindigkeit etwas Zeit in Anspruch nehmen.</b>
	
	docker-compose up

5) Webbrowser starten und die Seite <a href ="http://localhost:15106">http://localhost:15106</a> öffnen. 
Wenn alles korrekt gestartet ist siehst du folgende Seite.

6) Anwendung mit CTRL + C beenden

7) Container bereinigen 

	docker-compose rm
	
	Hinweis: die Images bleiben auf dem System erhalten
