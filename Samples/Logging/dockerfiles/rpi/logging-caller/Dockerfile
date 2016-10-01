FROM fpommerening/rpi-mono
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-01
ENV Caller_VERSION 0.0.3

 RUN set -x \
	&& apt-get update && apt-get install -y --no-install-recommends ca-certificates wget p7zip && rm -rf /var/lib/apt/lists/* \
	&& wget -O /home/logging-caller.7z "https://github.com/fpommerening/DevOpenSpace2016/releases/download/$Caller_VERSION/logging-caller.7z" \
    && p7zip -d /home/logging-caller.7z \
    && mv /logging-caller/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["mono", "Caller.dll"]

