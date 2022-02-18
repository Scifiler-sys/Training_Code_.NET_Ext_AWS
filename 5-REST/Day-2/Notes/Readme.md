# Moar HTTP
* You don't have to memorize it for QC but it will make HTTP as a whole makes more sense as I explain other topics

## HTTP Request
* It is essentially what the client sents 
* It will tell what HTTP verb the request will be all about (either GET, POST, PUT, etc.)
* It will tell what kind of actual data the client is trying to sent (in a JSON format)
* It has a bunch of other useful metadata things you don't need to know like ip addresses, urls, etc. things that might be useful for debugging purposes

## HTTP Response
* It is essentailly what the server sends back to the client
* It will give a **status code** if it was successful or not
* More metadata stuff for debugging purposes
* What kind of data the server is trying to sent to the client (in a JSON format)

# ASP.NET
* Another framework included in our .NET 6 that specializes in creating web application in either C# or VB
* For us, we will just use it to create a restful web api instead of including the frontend tech just yet

## Controller
* Their main responsiblity is to handle HTTP requests and formulate an appropriate HTTP response based on what functionality it is trying to achieve
* This is why the first thing we do to define an action (basically a method inside of controller) is to tell it what HTTP verb it should handle
    * Ex: [HttpGet] - no surprises handles http get requests
* You also specify the actual route/endpoints the client needs to use for specific functionalities inside of your controller
    * Ex: [Route(api/[controller])] - the endpoint has to be (website name).com/api/(The controller name)
* It will call on the appropriate business logic to process what the clients wants to do
    * You essentially replaced the console project to instead just have the web api project as the starting point

## Model Binding
* It is a way to bind data (JSON objects) coming from HTTP request to be automatically mapped into a C# model
* Remember how HTTP transfers information via JSON files? Well ASP.NET can automatically map that JSON object into a C# object
    * So instead of manually mapping it like our DL, it does it for us
    * Just need to know the fancy name that does that operation which is model binding
* Ex: controller action([FromBody] someModel p_model)
    * Mapping whatever JSON file you got into a "someModel" object that C# understands
* Model binding can also do it from C# object into JSON object
    * When we return a C# object in an action, it automatically creates a JSON object that gets put into an HTTP response

## Routing
* Allows ASP.NET to know where to take the user's http request
    * In our case, which controller and which action inside of the controller should the http request go to
* It uses **routing middleware** to be able to find the appropriate controller and then the appropriate action within the controller to handle the request
    * It is the middleman between the asp.net app and the client
    * It also handled http responses and routes that information back to the client

## Filters
* They are used to create your own custom logic (your own code) if a certain event has happened
    * Applies to most filters but not all
### Authorization
* Used to determine whether the user is authorized for the request
* This will run first
### Resource
* Used for logging, caching, and other resource related operations
* You can configure whether to run the resource filter first or after an action
* Ex: OnResourceExecuting filter will run your custom code first before doing any model binding operations
* For optimization purposes
* Runs after Authorization
### Action
* Will perform your custom code after or before a controller action
### Exception
* Will perform your custom code after or before an exception
### Result
* Will perform some code after or before the execution of giving a view or IActionResult

## OpenAPI (Swagger)
* Just the fancy technical term for Swagger
* Swagger is a tool pre-built in our ASP.NET project with the sole purpose of checking if our rest api is definitely working
* As you have guess, we don't really have a console app so we can visually see that our app is working so they created swagger just for the purpose
* It will show you every action inside of a controller and also test them
    * It can check what http response body it gave
    * It can check what http request the client needs to give to make it work and so on
* Really useful debugging tool for our api

## ASP.NET Caching
* Storing information in your app and just recalling that information rather than doing another operation on your database
* Useful if you expect to use that information multiple times to do a single operation
* Useful if your function does a complex sql operation to get that data that takes time and to store that information to call on instead
* Might cause problems if database gets updated and using the cache information will be outdated

# LINQ
* Language-Integrated Query
* It is a query language that is very similar to our SQL but we can use it in C# or VB
* So like any query langauge, it is incredibly useful for filtering/acquiring/aggregating data
* Very useful documentation click [here](https://www.tutorialsteacher.com/linq)
## Method syntax
* It is more like C# in that you use methods to perform the queries
* For simeple filtering, I would use method syntaxes
## Query syntax
* It is more like SQL in that you create a statement-like operation using keywords
* I would use joins with query syntaxes since it is easier to understand

# Asynchronous Programming
* Remember how concurrent things happening at the same time complicated a lot of things (Talking about you Isolation in ACID)
* Since we are deploying this on a web service, we have to take into account multiple people using your rest api at the same time
* Here comes Asynchrnous programming, It is the process of allowing two things to happen at once
    * Gone are the days of looking at your code line by line but your code might run multiple lines of code together
    * Debugging will .... be harder for sure

# Delegates
* It is when you want to put a method inside of a variable to call on multiple times
* We used lambda delegate multiple times (where we put a "=>" syntax) to be able to put a method inside of a parameter
* So one of the main uses of delegates is being able to pass methods as a parameter of another method for that method to use
    * It is like inception movie... a method within a method within a method...




