FROM mono:4.4.2
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-09-04
COPY app/ /app
WORKDIR /app/
EXPOSE 15106
ENTRYPOINT ["mono", "StartupApp.exe"]