#!/bin/bash
while ! mysqladmin ping --host=$MYSQL_PORT_3306_TCP_ADDR --silent
do
    sleep 1
done
while ! [[ $(mysql --host=$MYSQL_PORT_3306_TCP_ADDR --user=$MYSQL_USER --password=$MYSQL_PASSWORD $MYSQL_DATABASE -e 'show tables like "snipe_it_test_token";' 2>/dev/null ) ]]
do
    sleep 1
done
while ! [[ $(mysql --host=$MYSQL_PORT_3306_TCP_ADDR --user=$MYSQL_USER --password=$MYSQL_PASSWORD $MYSQL_DATABASE -e 'select 1 from `snipe_it_test_token` limit 1;' 2>/dev/null ) ]]
do
    sleep 1
done
mysql --host=$MYSQL_PORT_3306_TCP_ADDR --user=$MYSQL_USER --password=$MYSQL_PASSWORD $MYSQL_DATABASE -se 'select `token` from `snipe_it_test_token`;' 2>/dev/null
