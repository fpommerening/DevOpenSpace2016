FROM fpommerening/devopenspace2016:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-24
ENV Console_VERSION 0.1.1

RUN set -x \
	&& wget -O /home/logging-console.7z "https://github.com/fpommerening/DevOpenSpace2016/releases/download/$Console_VERSION/logging-console.7z" \
    && p7zip -d /home/logging-console.7z \
    && mv /logging-console/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "ConsoleListener.dll"]