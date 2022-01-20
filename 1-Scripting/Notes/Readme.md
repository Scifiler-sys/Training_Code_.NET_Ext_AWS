# Scripting Fundamentals
## Command Line Interface (CLI)
* It is an interface (basically mean something you can mess with) that interacts with your computer to do certain operations
* It can make folders, open folders, or do a plethora of other functionalities
* So why is this important when you can do the same operations (for the most part) with a file explorer?
    * Well in the coding world, there is no such thing as a pretty UI
    * Everyone is more focused on the functionality than adding a nice graphical representation of it
* So get ready to get used to seeing a terminal and messing with it. Down the line, we will add more functionalities to our basic CLI to do cool things
* You will also see that most of the common problems you'll experience is most likely or not the wrong usage of the terminal

## Shell
* While the CLI is how the user interacts with the computer, a shell is essentially the brain
* It will look at what the user inputs on the CLI and interpret it to do the operations
* To be able to understand what the user is trying to ask it to do, it has pre-made keywords that the user can do
* Want to change directory? Well the user needs to type "cd" on the CLI to undersand that you want to change directory. Anything else you type it may not understand it and shell will also let you know that it didn't understand it

## Shell Commands
* Help - shows all the potential commands you can use in the terminal 
    * pretty universal that any added shell commands we get from installing a library, SDK, or framework will have a help command to show their specific commands
* Pwd - shows the current directory the terminal is in
* Ls - Lists all the files inside of that directory 
* Cd - Changes the current directory of the terminal is in
* Mkdir - Makes a directory
* Echo - Displays text to the terminal
* Touch - Updates the time stamp of the file
    * Can also be used to create a file
* Grep - Searches for patterns in a file
    * Think of the feature (CTRL+F) that finds certain words in what application you are using
* Cat - concatenate/combine two files together
    * If they are text files, it will combine the text files together and show both their contents
* Which - Locates the path file of your commands in the terminal
* Find - Finds certain directories of files
    * Think of the search bar in your file explorer that finds certain filenames
* Nano - Allows us to edit files
    * Think of notepad

## GIT
* It is a Version Control System (VCS)
    * Allows you to manage the changes/developments made in a project
* As you know, the more you develop your application the more changes you add to it and it becomes impossible to track it manually. GIT does it for us.
* It will create a local repository for us.

### What is a Repository?
* It is the one responsible for storing all the information of all the changes you have made to your project files.

### So where does Github comes into play?
* Github is just a cloud service that stores your repository in the cloud (internet) for everyone else to have access to your project and all the changes you've made to it.
* Github is essential to the process because it lets us work on the same project with multiple people. 
* Just imagine 5 people trying to access the same computer just to work on the same project. That would be a nightmare!
* Instead, we use Github to create a remote repository that we can share with everyone else and they can work on their **own** copy of the project in their **own** computer (in a more technical term is they will create a local repository that is similar to the remote repository). Once they finish, they can **push** (Just means upload) their version of local repository to the remote repository to update the remote repository to look like the local repository.

### Pros
* Allows you to keep track of all the changes to each file to help you debug potential issues
* Allows you to backtrack to previous version of your code if your current version is too unstable
* If local files gets corrupted, you can get the files stored in Github to restore it

### Cons
* You might have merge conflicts
    * Just imagine one peson worked on the same file as another person and Git doesn't know which modified version to use
* Quite confusing when working with it the first time

## Useful Git commands to know
* git init - creates an empty local git repository
* git status - check which files are in staging and which aren't in staging
* git add . - Will add every file to staging (except for ignored files)
* git commit - Will record the changes to the local repository
    * Adding -m will let us attach a message to that commit
* git branch - will create, delete, or list branches for us

### Useful link to understand all the commands you can use with Git
* [A nice game that visalizes what Git does](https://learngitbranching.js.org/?locale=en_US)
* [Git Documentation](https://git-scm.com/doc)