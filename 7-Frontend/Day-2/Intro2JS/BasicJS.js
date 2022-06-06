function CreatingObjectsFunction() {
    let dog = {
        color: "Black",
        size: 40,
        speak: function() {
            console.log("Bark Bark!");
        },
        howBig: function() {
            //You must use the "this" keyword to specify you are using the object's own properties
            console.log("The dog is "+this.size+"lbs!");
        }
    }

    console.log(dog);
    dog.speak();
    dog.size = 192;
    dog.howBig();
}

function CreatingClassesFunction() {
    /*
        Creating classes is also possible with JS (although this used to not be the case)
        It has some OOP pillars working in JS while others not so much
    */

    //This is a class almost similar but doesn't have access modifiers (since that doesn't exists in JS)
    class Animal {
        //How to create a constructor
        constructor(name){

            //This automatically creates a field in the class called name
            this.name = name;
        }
        
        //How to create a method (notice no return method or access modifier)
        speak(){
            console.log("Hello");
        }
    }

    //Inheritance works the same way as C# but uses extends keyword
    class Dog extends Animal {
        //public field
        //The only closes thing to having access modifiers
        color = "Black";

        //private field
        //Useful for encapsulation
        #size = 20;

        constructor(color, size, name){
            super(name);
            this.color = color;
            this.#size = size;
        }
        
        //This is a method
        speak() {
            super.speak(); //To call on parent's method
            console.log("Bark! Bark!");
        }

        //Polymorphism doesn't work that well and can't do method overloading
        // speak(word){
        //     console.log(word);
        // }
        whatColor() {
            //Will this work to refer the variable inside of the class?
            //This keyword is what will refer to the field inside of the class
            //THIS IS VERY IMPORTANT OR ELSE YOU GET SOME WEIRDNESS
            console.log("The dog is "+this.color+".");
        }

        howBig() {
            //Must create methods to access private fields
            console.log("The dog is "+this.#size+"lbs!");
        }

        //Very similar to how C# does properties
        //There is such a thing called javascript properties but have no correlation to C# properties
        //These are just called getters and setters
        //Getter
        get Size(){
            return this.#size;
        }

        //Setter
        set Size(p_size){
            this.#size = p_size;
        }
    }

    let dog1 = new Dog("Black", 20, "Minnie");
    dog1.speak();
    let color = "White";
    dog1.whatColor();
    dog1.howBig();
    console.log(dog1.color);
    // console.log(dog1.#size); //Cannot access due to it being private
    console.log(dog1.Size);
    dog1.Size = 30;
    console.log(dog1.Size);

    //Be careful with doing this because it seemed like I set the size variable but not really
    //Instead JS created a new field inside the object called size that is public and sets its value
    //... yes you can set fields on an already made object unlike C# where it is very strict
    dog1.size = 200;
    console.log(dog1.size);
    console.log(dog1);

    //Inheritance
    console.log(dog1.name);

    //Method overriding
    dog1.speak("Doggy is talking");
}

function DomFunction() {
    /*
        Biggest thing as to why even use JS in frontend
        In an HTML you have a bunch of tags to structure a website
        JS DOM essentially lets us have access to those HTML elements and change them in many ways
        Document Object Model
        Called this way because HTML is just a document, object since JS uses objects and manipulates them, finally model since it models your website 

        TLDR: lets us dynamically change our website
    */

    //Lets start by creating an element
    let spanElement = document.createElement("span");
    spanElement.innerHTML = "This is a span created by JS!"; 
    //Creating an element is not enough to display it
    //We have to tell JS where to put it in the HTML
    document.querySelector(".addElementHere").appendChild(spanElement);

    //Selecting the element and changing its style
    //GetElementById is create for adding CSS
    //querySelector is for appending (technical term for attaching) an element to another element
    document.getElementById("DOM").style.color = "red";
}

function StorageFunction() {
    //Saves the information inside the client's local storage
    localStorage.setItem('Name', 'Stephen');

    //Grabs the information inside the client's local storage
    //Even if you refresh the page, the data is stored in the computer and so it will not be lost
    console.log(localStorage.getItem('Name'));

    //There is also session storage that is identical to local storage except the data is not perminent
    //Think of signing on a bank website, you can only stay signed in for a couple of minutes then it logs you out
    //Any information that the bank stored in your computer is now lost the moment you got signed out
}

function PropertyFunction() {
    console.log(PropertyFunction.prototype);
    PropertyFunction.prototype.anotherProp = "Adding a new prototype in this function";
    console.log(PropertyFunction.prototype);
    console.log(PropertyFunction.prototype.anotherProp);
    console.log("Example of Prototypal Inheritance");
    let animal = {color: "blue"};
    let dog = {talk: "bark"};
    console.log(dog.color);
    dog.__proto__ = animal;
    console.log(dog.color);
}