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

# Control Flow
# They are a way for us to tell the program what lines of codes we want to run

# If Statements
# Like the english word if, it will only run the lines of code if it is true
ten=10
five=5
thirteen=13

# since 10 > 5 then it will run the lines of code
echo "===First If==="
if [ "$ten" -ge "$five" ]
# Anything between "then" and "fi" will execute
then
echo "greater!"
echo "$ten > $five"
fi

echo ===Second If===
# since 10 is not > 13 then it won't run the lines of code
if [ "$ten" -ge "$thirteen" ]
then
echo "lesser!"
echo "$ten > $thirteen"
fi

echo ===Third If===
# What if you need to check several conditions instead?
if [ "$five" -ge "$ten" ]
then
echo "greater!"
echo "$five > $ten"
elif [ "$five" -le "$ten" ]
then
echo "lesser!"
echo "$five < $ten"
fi

# What if you want to run something if everything failed?
echo "===Fourth If==="
if [ "$five" -ge "$ten" ]
then
echo "greater!"
echo "$five > $ten"
elif [ "$thirteen" -le "$ten" ]
then
echo "lesser!"
echo "$thirteen < $ten"
else
echo "nothing works!"
fi

# Loop statements
# It will run the lines of code multiple times as long as it is true

# For loop
# Will repeat the code x amount of times (you determine how much you want it to repeat)
# Useful if you know how many times you want to repeat the line of code

echo "===For loops==="
for num in 1 2 3 4 5
do
echo num currently has $num
done

for num in {1..10}
do
echo num currently has $num
done

# While loops
# Will repeat the code multiple times as long as the condition is true
# So think of the if statement but it will keep running that line of code

echo "===While loops==="
while [ "$five" -le "$ten" ]
do
    echo $five
    five=$(($five+1)) #$((numerical expression)) this is the syntax needed to do numeric operations
done

# Input and Output
# We can ask for input from the user that is using this shell script and output some sort of response
echo What is your name?
# read [whatever variable name you want]
read name #read shell comand will store the user input and put it on the name variable
echo Hello $name, Welcome to programming!
echo Hi $name, I hope you are ready to learn a lot!


# We can combine Input and Output with While loops to create a menu like interface
clear #shell command that clears the screen
repeat="true" #Variable we will use to keep repeating the while loop if needed
 
while [ "$repeat" == "true" ] 
do
 echo "Welcome to shell scripting!"
 echo "What do you want to do today?"
 echo "enter 1 for add two numbers"
 echo "enter 2 to exit"
 read ans
 if [ "$ans" == "1" ]
 then
    echo "Give me two numbers"
    read num1
    read num2
    echo "This is your answer $(($num1+$num2))"
    echo "Press Enter to Continue"
    read pause
 elif [ "$ans" == "2" ]
 then
    repeat="false"
 fi

 clear
done