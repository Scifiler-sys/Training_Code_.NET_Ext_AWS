# This is a comment to add more information to your code
# It is like putting a sticky note in your code
# The shell script will ignore anything inside a comment like it doesn't exist
# echo Testing Comment - will not run
echo Hello World #This will run

# Variables
# They are a way for us to store information in our code for us to later use
msg="Hello World Variable" # Creates a msg variable that stores "Hello World Variable"
echo $msg #$ syntax is what we need to reference a variable
# syntax is just the way we write things for it to work

# Input and Output
# We can ask for input from the user that is using this shell script and output some sort of response
echo What is your name?
# read [whatever variable name you want]
read name #read shell comand will store the user input and put it on the name variable
echo Hello $name, Welcome to programming!
echo Hi $name, I hope you are ready to learn a lot!
