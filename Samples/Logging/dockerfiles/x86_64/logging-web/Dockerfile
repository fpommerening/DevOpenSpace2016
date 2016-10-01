FROM microsoft/dotnet:core
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-09-18
ENV Web_VERSION 0.0.3


RUN set -x \
	&& apt-get update && apt-get install -y --no-install-recommends ca-certificates wget p7zip && rm -rf /var/lib/apt/lists/* \
	&& wget -O /home/logging-web.7z "https://github.com/fpommerening/DevOpenSpace2016/releases/download/$Web_VERSION/logging-web.7z" \
    && p7zip -d /home/logging-web.7z \
    && mv /logging-web/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip


WORKDIR /app/
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebLogger.dll"]