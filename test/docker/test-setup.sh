#!/bin/bash
while ! mysqladmin ping --host=$MYSQL_PORT_3306_TCP_ADDR --silent
do
    sleep 1
done
php artisan snipeit:initialize-test --username=$TEST_USERNAME --password=$TEST_PASSWORD
/startup.sh
