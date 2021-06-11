import { Quiz } from "./Quiz";
/*
    command tsc [filename] will transpile the TS file into JS
    command tsc [filename] -w will tranpile the TS file and set into watch mode that any saved changes
        will automatically trigger a transpile
    command tsc -t es[ECMA Script Version] [filename] will transpile to the specific ES version
        the default is ES 5
*/
// console.log("This is not Hello World");
// console.log("hello world");
/*
    What are the Datatypes in TS?
    string, number, boolean, null, object, function, bigint, undefined, array, enum,
    void, any, never, symbol


*/
//=================================== VARIABLES ===================================
console.log("==== VARIABLES ====");
//Lets test the strict typing nature in ts
let s1 = "hello"; //If I assign a declared variable a value in the same expression it will strictly type
//the variable to the datatype it is assigned to
// s1 = 5; //Note: ts gives compile error about violating strict type nature
// but it will still able to transpile since js is not strict type nature
console.log(`s1 is type of ${typeof s1}`);
s1 = "hello ";
let s2;
s2 = "world";
console.log(`${s1} ${s2}`);
//ANY - is the default type of a declared variable if no type implicitly and explicitly given
let a1; //no type default-undefined
a1 = "string";
a1 = 1;
a1 = null;
a1 = false;
console.log(`a1 is type of ${typeof a1}`);
//NUMBER
let n1 = 5;
//You can give multiple types to a variable using the | inbetween the types
let m1;
m1 = "hello";
m1 = 6;
//DO NOT use void or never as datatypes for variables, void is for function return types
//Never is for  error handling 
//NULL and UNDEFINED
let nul1; //undefined because you didn't assign it with anything
let un1 = null;
console.log(`nul1: ${nul1} un1: ${un1}`);
//ARRAYS
let arry1; //This creates a variavle that can have an array of any datatypes
arry1 = ["one", false, 5, null];
console.log(arry1);
arry1.push(4);
console.log(arry1);
let arr2;
arr2 = [3, true, false, 5];
let arr3;
arr3 = 3;
arr3 = [true, false, true, true];
//TUPLE - it is an array that can contain only two values of fixed type
let tul;
tul = [5, ""];
//ENUMs, enumeration, specified set of named constants. Easier to document intent (Only in TS)
let engine;
if (engine == 0) //Not as clear seeing how 0 means engine is off without looking at code 
 {
    console.log("The engine is off");
}
var Engine;
(function (Engine) {
    Engine[Engine["Off"] = 0] = "Off";
    Engine[Engine["Idle"] = 1] = "Idle";
    Engine[Engine["Accel"] = 2] = "Accel";
})(Engine || (Engine = {}));
;
let engineState = 0;
if (engineState == Engine.Off) //A lot more clear
 {
    console.log("The Engine is Off");
}
//=================================== FUNCTIONS ===================================
console.log("==== FUNCTIONS ====");
function myFunc(para1, para2) {
    console.log(`para1: ${para1} para2: ${para2}`);
}
myFunc(5, "hello");
function myFunc2(para1) {
    return para1.concat(" DOOM");
}
console.log(myFunc2("MF"));
//=================================== CLASSES AND OBJECTS ===================================
console.log("==== CLASSES AND OBJECTS ====");
class SuperVillain {
    constructor(name, superpower, bounty) {
        this.name = name;
        this.superpower = superpower;
        this.bounty = bounty;
    }
    useAbility() {
        console.log("in object method");
        console.log(`${this.superpower} is unleashed`);
    }
}
let vill;
vill = new SuperVillain("Jacob", "Projects enforcer", 5);
console.log(vill);
vill.useAbility();
class VillainOrg extends SuperVillain {
    constructor(name, superpower, bounty, title) {
        super(name, superpower, bounty);
        this.title = title;
    }
}
let villOrg = new VillainOrg("Red Skull", "Tesseract", 50000, "Hydra");
console.log(villOrg);
villOrg.useAbility();
class Pet {
    // private name:string;
    // protected age:number;
    // public breed:string; //This the default for TS
    constructor(name, age, breed) {
        this.name = name;
        this.age = age;
        this.breed = breed;
        /*
            if we provide the acess modifier for the variables in the constructor, it will
            automatically declare those variables as fields of the class and assign the values passed
            in when the constructor is called
            same as coding it as
            this.name = name;
            this.age = age;
            this.breed = breed;
        */
    }
    get Name() {
        return this.name;
    }
    set Name(v) {
        this.name = v;
    }
}
let pet1 = new Pet("Minnie", 1, "Chihuahua-Mixed");
console.log(pet1);
let pet2 = new Pet("Jacob");
console.log(pet2);
pet2.Name = "Jacom";
console.log(pet2.Name);
let ani;
ani =
    {
        numOfLegs: 4,
        isAlive: true,
        speak() {
            return "Bark";
        }
    };
class Dog {
}
//ARROW NOTATION
console.log("==== ARROW NOTATION ====");
let arrEx = (para1) => console.log(para1);
arrEx("Arrow Function");
let arrEx2 = () => {
    console.log("Multi-Line");
    console.log("Arrow Function");
};
arrEx2();
////=================================== MODULES =================================== 
/*
    *It is organizing code into 'packages' of like functionality
    *Internal modules were used in early version of TS, it was used to group classes, interfaces,
    and functions into one unit

    *External modules exist to specify and load dependencies between multiple external js and ts files
    to declare a module in other files we use the export keyword. External modules will use the
    namespace(path to the file) to reference them
    we can use import keyword followed by namespace.
    
    Will not work without using Angular
*/
function printQuize(q1) {
    console.log(`The quiz name is ${q1.name}\n Grade: ${q1.grade}`);
}
let quiz1;
quiz1 = new Quiz("Math", 89);
printQuize(quiz1);
