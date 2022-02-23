# DevOps
* It is a culture that you follow in which you continuously develop your application and continuously deploy it
* DevOps are integrated with Agile planning since they have similar ideologies
* There are three main teams that are a part of DevOps
    * Developer Team are responsible for planning, testing (with unit tests), and building the application
    * Operation Team are responsible for deploying, testing (by emulating real world experience), and maintaining the application
    * Business Team verifies that the correct product is created and delivered correctly
        * May or may not also set unrealistic expectations

## Continuous Integration (CI)
* The process of automating the build and testing of your code
* Usually triggered via a pull request/merge on your main branch of your remote repository
* Testing is done through unit tests and will only merge if all unit tests passes
## Continuous Delivery (CD)
* The extension of CI since CI does is checks if your main branch is working properly after a merge
    * Hence we usually denote them as CI/CD since both are usually combined together
* Essentially, it is the automated process of delivering the new changes in the main branch to the people
* However, there is a **release manager that will check on everything before deployment**

## Continous Delivery
* In its essence, it is the combination of both Continuous Integration and Continuous Delivery
* The main difference is there is essentially no human component involved in the entire process. Once you do a merge with the main, it will start deploying it after all the testing are done and passed
    * So no release manager and everything is managed/tested by computers

## YML
* Another mark up language that just tells the computer what to do so it can build, test, and deploy our application to setup a CI/CD pipeline
### Pipeline keywords
* Trigger
    * We set some sort of event that needs to happen to trigger/execute the entire process of CI/CD
* Job
    * This is the actual "work" the computer needs to do to start the entire process
    * You can have multiple jobs that is responsible to do something
    * Ex: Deploy the application job, Dockerize the app job, Code analysis job
* Steps
    * They are the tiny operations required for the computer to finish one job
    * This might be executing a bunch of CLI commands in sequence or installing certain SDKs to do the operation, etc.
* Approval
    * Some sort of a check after a job or multiple jobs to see that everything work as expected

# Introduction to Code Analysis
* A further way for a computer to analyze your code to ensure you are following good coding practices and also gives you a direction on certain things you might want to change
* Does not actually check if the functions are working on your app (that is what unit tests are for) and more about looking at your c# files and ensuring you follow good coding practicies
* It will perform a **static code anaylsis**
    * Just the fancy way of saying, it will check your code without running it and just scanning your c# files and seeing any patterns that might be bad coding practices
    * If done by a human, that is what we call a code review (just for your fun information)

# Specific for Azure DevOps Cloud Services
* A couple features in Azure DevOps that might be useful for us when utilizing that service to create our pipeline
* However, note that we used github actions to do our pipeline and not Azure DevOps
* Packages
    * They are just pre-made files made by someone that another person can come and download and start using it as well
    * Can also be done with pipelines in which we just pre-made pipelines and just change some configuration to tailor it to us
* Artifacts
    * Essentially, it is a market place for many packages
    * Ex: NuGet