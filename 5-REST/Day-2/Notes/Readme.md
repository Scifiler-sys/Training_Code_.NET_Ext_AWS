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