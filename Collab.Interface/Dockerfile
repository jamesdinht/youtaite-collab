FROM mhart/alpine-node:10
WORKDIR /app

# copy manifest and install before copying entire source - provides optimizations when rebuilding
COPY package.json yarn.lock ./
RUN yarn install

# copy everything else
COPY . ./

CMD ["yarn", "start"]