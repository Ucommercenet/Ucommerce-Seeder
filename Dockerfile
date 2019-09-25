FROM mcr.microsoft.com/mssql/server

ADD db /var/db/

COPY db/* /var/opt/mssql/data/

ENV SA_PASSWORD=Pass@Word1

WORKDIR /var/opt/mssql/data/

RUN cp -f umbraco810_blank.mdf umbraco810_seeding.mdf
RUN cp -f umbraco810_blank.ldf umbraco810_seeding.ldf

EXPOSE 1433

CMD [ "/opt/mssql/bin/sqlservr" ]