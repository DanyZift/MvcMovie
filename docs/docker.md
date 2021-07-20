# Docker Commands

### Build an Image from a Dockerfile 
You need to be in the root folder where the Dockerfile is located. For example the Dockerfile lives in MvcMovie/Dockerfile. Run the below command while inside the MvcMovie folder:

```
docker build -t mvc-movies-app .
```

### Run a Image
The port is set to 8001 on the Dockerfile but the .net app runs on port 5001. The flag -p allows you to access the MVC app inside the container from your browser on port 8001. 

```
docker run -d -p 8001:5001 mvc-movies-app
```

Once the above command is run, open your browser on https://localhost:8001 and you should see the application. 

If you encounter an issue such as "Your connection to this site might not be secure" - click Advanced, then click Proceed and then reload the page.

For further info on any of the commands above use the docker run --help command to see the full listings.