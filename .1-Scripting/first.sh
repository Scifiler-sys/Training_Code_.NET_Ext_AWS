# This is a comment to add more information to your code
# It is like putting a sticky note in your code
# The shell script will ignore anything inside a comment like it doesn't exist
# echo Testing Comment
echo Hello World #You can also put a comment after a command

msg="Hello World"
echo $msg

echo What is your name?
read name #read cmd stores user input to a variable 
echo Hello $name, Welcome to Programming!
echo Hi $name, I hope you are doing ok
echo

# Control Flow
# Types of Loops
# For loops - They will repeat something a set number of times
for variable in 1 2 3 4 5 do
do
   echo Variable currently holds: $variable
   echo repeating
done
# While loops - They will repeat something until the condition isn't satisfied anymore

condition="true"

while [ "$condition" != "false" ] #Be sure there is a space
do
   echo "Do you want to repeat? (true or false)"
   read condition
   echo "You typed: $condition"
   if [ $condition == ]
done

