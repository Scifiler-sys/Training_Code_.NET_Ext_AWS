# Group Activity
* Trust me two weeks is not a lot of time, it is best to start completing those functionalities than waiting for me to keep showing you more features or functionalities you can add to the project
* If you implementation works like mine then just keep it
* It is just required for you to save it in a JSON file (our acting database at the moment)

# Finish one functionality from SDD
* Since you know all the projects needed for the application
* Complete at least one functionality stated in SDD
* I would suggest finishing addCustomer functionality
1. Update DL project to start interacting with a json file preferably stored in a Data folder
2. Update BL project to add further validation process (if required) to the DL
    * Make sure you incorporate dependency injection right or else it will give you a massive hassle later down the line
3. Update UI project to start using functionality from the BL project (and also test if everything is working as intended)
    * You can comment out your entire program.cs file to just start testing the DL if you want. That might be easier to debug

## Tips
* The UI should only depend on the BL and Model project
* The DL should only depend on Model
* The BL should only depend on the BL and Model
* If you messed up with the dependencies, your entire application will start to act very weird (you might have 100+ errors that might pop up)
* Don't forget to add the new projects to a solution file, this is how intellisense will start checking multiple projects for possible error
