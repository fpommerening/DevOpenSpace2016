FROM postgres
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-10
ENV POSTGRES_USER devspace
ENV POSTGRES_PASSWORD leipzig
ADD init.sql /docker-entrypoint-initdb.d/
EXPOSE 5432