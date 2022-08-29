let param1 = "Hello";
let param2 = " World";

let function1 = (p1, p2) => console.log(p1 + p2);

function1(param1, param2);

function callback(anotherFunction) {
    let p1 = "Not Hello";
    let p2 = " World";

    anotherFunction(p1,p2);
}

callback(function1);

//IIFE - Immediately Invoked Function Expression
(() => {
    console.log(param1 + param2);
})();

function GiveBack() {
    return "Hello World";
}

GiveBack()