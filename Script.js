// JavaScript source code

// Task 1
//Please, define variable with value "I can eat bananas all day".
//Use the slice method to return the word "bananas".Then convert it to upper case and alert the result.

const message = 'I can eat bananas all day';

const bananas = message.slice(10, 17).toUpperCase()

alert(bananas)

// task 2
//Please, define array with the following values "Saab", "Volvo", "BMW". Then perform the next operations by using JavaScript: 
const types = ["Saab", "Volvo", "BMW"]

// get "BMW" value 
const bmw = types[types.indexOf(x => x === "BMW")];

// change the first item of cars 
types[0] = "Volskwagen";
console.log(types)
//  remove last item in the array 
types.pop()
console.log(types)
// add "Audi" to the array 
types.push("Audi")
console.log(types)
types.splice(-2)
console.log(types)
