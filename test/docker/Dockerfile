FROM snipe/snipe-it:v4.9.5
COPY InitializeAndGenerateTestToken.php /var/www/html/app/Console/Commands/
COPY test-setup.sh get-token.sh /
RUN chmod +x /test-setup.sh /get-token.sh
CMD ["/test-setup.sh"]
