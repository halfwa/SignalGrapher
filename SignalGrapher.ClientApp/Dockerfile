FROM node:20.11.0-alpine
WORKDIR /app

COPY package.json .
COPY package-lock.json .
RUN npm ci

COPY . .
RUN npm run build
CMD [ "npm", "start"]