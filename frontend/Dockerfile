FROM node:16-alpine AS builder
WORKDIR /app

COPY tutorium/package.json tutorium/yarn.lock ./
RUN yarn

COPY tutorium/. .
RUN yarn build

FROM nginx:alpine AS runtime
WORKDIR /usr/share/nginx/html
RUN rm -rf *
COPY --from=builder /app/build .
ENTRYPOINT ["nginx", "-g", "daemon off;"]
