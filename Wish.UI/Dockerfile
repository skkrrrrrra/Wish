FROM node:lts-alpine as build-stage
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist/wish.ui /usr/share/nginx/html
EXPOSE 80-443
CMD ["nginx", "-g", "daemon off;"]