# Docker
* It is a way of packaging our application that has a bunch of dependencies that we had to install (SDK, external packages, etc.) into one single package that we can send to multiple computers and have it run flawlessly without the need of any installation process or setup process
* It is a containerization ecosystem (more on this on the later notes)

## What is Containerization?
* Involved bundling an application together with all the configuration files, libraries, and dependencies required
    * Basically get everything the application needs to run it
* When creating a container, the allocation of resoruces is dynamic
    * Meaning it will use as much resrouces the container needs to run the application
    * Ex: If running your app requires 1 gb of ram then it will just need that 1 gb of ram and will either increase or decrease that required depending on the workload

## What is Virtualization? (VM)
* It is a creation of a virtual machine that simulates a real computer with an operating system
* Ex: Macbook needs to create a windows virtual machine in their computer to be able to run windows only operated application
* When you create virtual machine, the allocation of resource is static
    * Meaning once you start a virtual machine, you have to specify how much gbs of ram needed and will not dynamically change depending on the workload
    * So it is like taking a piece of your computer's resource and will keep that piece until you close down the VM
    * Ex: We have 16 gb of ram in my computer, I stated the VM to use 8 gb of ram then my computer will only have 8 gb of ram and the VM will only have 8 gb of ram and that will not change until I close the VM

# What is the purpose of Docker?
* Analogy with business and hiring more people
* It allows developers to work in standardized environments using Containers
    * Meaning they can work with whatever development environment (Java, .NET, Ruby, etc.) they want with whatever OS (Windows, Linux, Mac, etc.) they want and still be able to give their application to everyone (as long as they have a docker engine)
* It makes it perfect for CI/CD workflows and for scaling
    * It is easy to spin up a new computer and have an application running to accomodate for more people (This is future topic but this is how container orchestration works)
    * Developers can write code locally in their own preferred development environment and then share it using Docker container

## Pros
* Responsive deployement and scaling
    * Docker containers can run on most things (physical or virtual machine, data center, cloud providers, etc.)
    * You can scal eup or tear down application as business dictates (based on demand)
* Run more worklods on the same hardware
    * Since containers is very lightweight unlike virtual machines, you can do other stuff while docker is running

## Docker artifacts/Terminology
* Docker Images
    * They are standalone package that includes everything for the application to run such as the code itself, dependencies, configuration, etc.
    * They are immutable file and represents an application and its virtual environment at a specific point in time
        * Immutable meaning you cannot change it thats why we have to create a new image everytime we update the application
* Docker Container
    * An image cannot run on its own. It needs a docker container to run the image
    * In other words, Containers are the runnable instance of a docker image
    * Think of a CD, it has all the information you need to start an application/install application/play music but it needs a disc drive to actually run it
* Docker Registry
    * It is a server-side or cloud application where you can store your images and make it easy to distribute to everyone else
    * Think of github but just for docker images
    * Ex: Dockerhub
* Docker ignore
    * It is like .gitignore
    * It will ignore certain files in your application to not put inside of image
* Docker Configuration
    * Just extra information to tell the docker container on how to run the image
    * We won't touch this and just use the default settings

## Docker instructions
* Don't confuse them with docker commands that is the CLI commands we put on the terminal
* These are instructions to tell docker how to make this image and what it needs
* From
    * Initialized our build stage and sets the base image
    * Essentially this is where we indicate what we need to be able to create/run our application
* Workdir
    * Sets the working directory
    * Just creates a folder and that is where we will copy and paste our files into that folder
* Copy
    * Copy and paste files for image
    * So it essentially moves the files from your local directory and paste into the image
* Run
    * It will execute the CLI commands you specify in the run command
    * Essentially, if you need to run something in the terminal (like dotnet build), you use the run instructions