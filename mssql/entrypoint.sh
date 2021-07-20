#!/bin/bash
for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@word -d master -i setupdb.sql
    if [ $? -eq 0 ]
    then
        echo "setupdb.sql completed"
        break
    else
        echo "waiting on setupdb.sql to finish ...."
        sleep 1
    fi
done