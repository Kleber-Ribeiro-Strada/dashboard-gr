FROM node:16-alpine as angular
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN ls
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=angular app/dist/front-angular /usr/share/nginx/html