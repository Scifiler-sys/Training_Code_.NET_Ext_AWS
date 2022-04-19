#Docker is like a virtual OS (not a VM) and like our CI/CD build agent, we have to specify what it needs to fully run our application
#So the first thing is getting the SDK so we can build and publish our application
#Unlike github actions, we get out SDK through another image that was already published by Microsoft themselves that we can just utilize
from mcr.microsoft.com/dotnet/sdk:latest

#workdir docker instruction let us create what our working directory will be in this virtual OS
workdir /app


#copy docker instructions let us copy the files from our computer into the docker image
#So in this case, we are copying our csproj files and putting it in their corresponding folders
#Also the solution file and putting it on the working directory 
copy *.sln ./
copy PokeApi/*.csproj PokeApi/
copy PokeBL/*.csproj PokeBL/
copy PokeDL/*.csproj PokeDL/
copy PokeModel/*.csproj PokeModel/
copy PokeTest/*.csproj PokeTest/

#Now that we have our csproj files, we can restore the dependencies that each project might need
#run docker instructions is to run terminal commands so in this case, cd into my webapi project and then run dotnet restore
#run dotnet restore

#Copy the rest of our source codes from our projects (the .cs files)
copy . ./

#Creating our publish folder by running the CLI command
run dotnet publish -c Release -o publish

#After getting all the dependencies restored and created our publish folder
#We don't need SDK as our main environment anymore
#To save space we will change our image environment to just the runtime of .Net
#from mcr.microsoft.com/dotnet/sdk:latest as runtime this is for the old way to just use the sdk
from mcr.microsoft.com/dotnet/aspnet:latest as runtime

workdir /app
copy --from=0 /app/publish ./

#CMD to set that PokeApi.dll assembly will be our default entrypoint
entrypoint ["dotnet", "PokeApi.dll"]

#Expose to port 5000
expose 5000

#Changes the port from the runtime image to listen to 5000
env ASPNETCORE_URLS=http://+:5000