//Encapsulation with IIFEs
let Outer = 
(
    () =>
    {
        let count = 0;
        return function Inner() {
            return count += 1;
        }
    }
)();

let bankAccount = money => (function(copyMoney) {
    let currentMoney = copyMoney; //Makes this variable essentially private so it cannot be access

    //We can also define a function within this IIFE like a method inside a class in C#
    return {
        withdraw: function(amount) {
            if (currentMoney >= amount) {
                currentMoney -= amount;
                return currentMoney;
            } else {
                return "Insufficient money";
            }
        }
    }
})(money);

//Encapsulation with regular functions
let Count = (
    () => 
    {
        let count = 0;
        return () =>
        {
            return count += 1;
        }
    }
);

//Added two different variable that points to the Count function
let add = Count();
let add2 = Count();