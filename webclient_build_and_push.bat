docker-compose up -d --no-deps --build webserver
docker tag diploma-webserver:latest cr.yandex/crppcoh55ab7v7unth77/diploma-webserver:latest
docker push cr.yandex/crppcoh55ab7v7unth77/diploma-webserver:latest
pause