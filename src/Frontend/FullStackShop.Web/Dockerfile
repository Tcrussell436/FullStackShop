ARG NODE_VERSION=20.10

FROM node:${NODE_VERSION}-alpine as base

ENV NODE_ENV=development

WORKDIR /src


FROM base as build

COPY --link package*.json ./

RUN npm install


FROM base

COPY --from=build /src/node_modules /src/node_modules

CMD ["npm", "run", "dev"]