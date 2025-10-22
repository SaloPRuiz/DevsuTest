Desde Devsu/DevsuBackEnd
- docker build -t devsu-backend:dev -f ./DevsuBackEnd.WebApi/Dockerfile .
- docker run -d -p 5000:5000 --name devsu-api devsu-backend:dev
