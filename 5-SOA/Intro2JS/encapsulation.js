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