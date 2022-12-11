FROM node:16-alpine AS builder
WORKDIR /app

COPY TutoriumWeb/package.json TutoriumWeb/yarn.lock ./
RUN yarn

COPY TutoriumWeb/. .
RUN yarn build

FROM nginx:alpine AS runtime
WORKDIR /usr/share/nginx/html
RUN rm -rf *
COPY --from=builder /app/build .
ENTRYPOINT ["nginx", "-g", "daemon off;"]
