FROM fpommerening/devopenspace2016:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-24
ENV Picflow_VERSION 0.1.1

# COPY /app /home/

RUN set -x \
	&& wget -O /home/picflow-webapp.7z "https://github.com/fpommerening/DevOpenSpace2016/releases/download/$Picflow_VERSION/picflow-webapp.7z" \
    && p7zip -d /home/picflow-webapp.7z \
    && mv /picflow-webapp/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "WebApp.dll"]