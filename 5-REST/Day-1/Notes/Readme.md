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

## HTTP status code
* Gives the result of the HTTP request
* 1XX - informational
* 2XX - Success
* 3XX - Redirection
* 4XX - Client error
* 5XX - Server error
