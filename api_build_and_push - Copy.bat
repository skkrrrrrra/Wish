docker-compose up -d --no-deps --build wishapi
docker tag diploma-wishapi:latest cr.yandex/crppcoh55ab7v7unth77/diploma-wishapi:latest
docker push cr.yandex/crppcoh55ab7v7unth77/diploma-wishapi:latest
pause