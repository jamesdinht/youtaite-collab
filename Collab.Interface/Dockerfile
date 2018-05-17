# build housing.web
FROM node:8
WORKDIR /app

# copy manifest and install before copying entire source - provides optimizations when rebuilding
COPY package*.json ./
RUN npm install

# copy everything else
COPY . ./

CMD ["npm", "start"]