FROM fpommerening/devopenspace2016:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-25
ENV Web_VERSION 0.1.2

# COPY /app /home/

RUN set -x \
	&& wget -O /home/logging-web.7z "https://github.com/fpommerening/DevOpenSpace2016/releases/download/$Web_VERSION/logging-web.7z" \
    && p7zip -d /home/logging-web.7z \
    && mv /logging-web/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip


WORKDIR /app/
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebLogger.dll"]