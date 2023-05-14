docker-compose up -d --no-deps --build webserver
docker tag diploma-webserver:latest flsab/diploma-webserver:latest
docker push flsab/diploma-webserver:latest
pause