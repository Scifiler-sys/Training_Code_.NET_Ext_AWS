# What we have been doing so far
* A monolithic architecture
    * Meaning the frontend (anything visual to the user and the backend (the actual logic that does the function) are tightly coupled)
        * Tightly coupled just means if you update one thing, it breaks another thing since they are highly dependent on one another
        * So in our context, if we update something in BL, DL, and Model (the backend), there is a good chance it will break something in our UI (the frontend)
## Pros
* Prototyping an application and getting something working right away
* Simple applications or working on your own 

## Cons
* Horrible for scaling the application
* Impossible to develop backend and frontend separately

# Service Oriented Architecture (SOA) Introduction
* A style of software design where services are provided to the other components by application components, through a communication protocol over a network
* Intuitive definition: We are decoupling backend and frontend and a communication protocol (can be HTTP, HTTPS, SMTP, etc.) to communicate between the two entities via the internet
## What are Services?
* They are responsible for sending and receiving data
* They provide some sort of functionality that clients might want 
    * like a service in the real world (i.e. you go to a barber place to get a haircut service)
* They are independent of platforms and programming language
    * Meaning you can create one using any programming language and once deployed, any programming language can use it
    * Ex: Creating a service with C# and having a java application use it
## SOA principles
* Many rules that you must follow to achieve SOA
### Standard Service Contract
* Must have a descritpion on what the service is about
* This makes it easier for a client to understand what the service does
### Loose Coupling
* Less dependency on each other (frontend and backend)
* So, if the service functionality changes at any point in time, it should (must) not break the client application or stop it from working
### Service Abstraction
* Services hides the logic
* You only know what the service does and how to use it but never on how they implemented the application
### Service Reusability
* Logic was made in a way that it can be re-used as many times as the client wants
* Other clients can also use your service at the same time without any issues
### Service Statelessness
* Service should not withhold information from one state to the other
* Ex: Any data used to do a functionality should be gone after doing the functionality
## Pros
* Frontend and backend can be developed separately without any problem
* A lot easier to scale
* Platform independent
## Cons
* High investment cost
    * You need two separate teams to do either frontend and backend
* As with adding more teams, communication can become an issue
    * Since frontend and backend are being developed separately they might not have the same idea on doing a functionality (which you might experience once you start working in teams!)

# HTTP/HTTPS
* Hyper Text Transfer Protocol (Secured)
* The protocol that both computers have to follow in order to understand/communicate with each other and work together to display a nice looking website in your browser, register an account, login, etc.

## HTTP Life Cycle
* An overview of what happens if you put in a url in your browser and out comes a website
1. Client (your browser) will send a request (the url you sent)
2. The server will receive that request and will do some processes
3. The server will send an appropriate response (html, css, js, json, etc.)
4. The client will receive the response and the browser will process that response

## Domain Name System (DNS)
* It is essentially a directory of names and ip address
* It translates a pretty loorking name of a website (www.google.com) into some numerical ip address ranging from (0.0.0.0 - 255.255.255.255) for locating the right server and to process the http request
* Main reason is the same reason why you save people's phone number in contact in a form of a name instead of just their phone number
    * It is easier to remember!

## HTTP Verbs/Methods
* Describes what action the client wants the server to perform on a given resource  
    * What is a resource? Anything the server is providing counts as a resource
* Common Verb
    * Get - Used to retrieve data from the server
    * Post - Used to submit data to the server
    * Put - Used to update/replace data on the server
    * Delete - Used to delete existing data on the server
    * Head - It is like the get method but it will only give you the header (metadata so no response body)

## HTTP status code
* Gives the result of the HTTP request
* 1XX - informational
* 2XX - Success
* 3XX - Redirection
* 4XX - Client error
* 5XX - Server error
