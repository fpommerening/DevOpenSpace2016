FROM fpommerening/devopenspace2016:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-22
ENV Picflow_VERSION 0.1.0

RUN set -x \
	&& wget -O /home/picflow-extapp.7z "https://github.com/fpommerening/DevOpenSpace2016/releases/download/$Picflow_VERSION/picflow-extapp.7z" \
    && p7zip -d /home/picflow-extapp.7z \
    && mv /picflow-extapp/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "ExternalApp.dll"]