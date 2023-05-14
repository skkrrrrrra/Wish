docker-compose up -d --no-deps --build wishapi
docker tag diploma-wishapi:latest flsab/diploma-wishapi:latest
docker push flsab/diploma-wishapi:latest
pause