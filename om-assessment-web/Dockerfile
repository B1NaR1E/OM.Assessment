
# Stage 1: Build the Angular application
FROM node:14-alpine as build
WORKDIR /app
COPY ../om-assessment-web/package.json ../om-assessment-web/package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

# Stage 2: Serve the application with Nginx
FROM nginx:alpine
COPY --from=build /app/dist/my-angular-app /usr/share/nginx/html
