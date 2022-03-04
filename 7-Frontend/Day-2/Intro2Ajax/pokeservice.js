//AJAX demo
function getPokemon() {
    let xhr = new XMLHttpRequest();

    let pokemon = {};

    let pokemonName= document.querySelector("#pokemonName").value;

    /*
        onreadystatechange describes the current state of your http request
        0 - uninitialized
        1 - loading (server connection has been established)
        2 - loaded (request received and response is currently being made)
        3 - Interactive (response is being by browser)
        4 - complete
    */

    xhr.onreadystatechange = function() {
        //if condition checks if the response is received and successful
        if (this.readyState == 4 && (this.status > 199 && this.status < 300)) {
            
            //API that converts a JSON object into JS object for us to use
            pokemon = JSON.parse(xhr.responseText);
            // console.log(pokemon); //Confirmed that the frontend has access to the backend

            //This will select our image element and set its src attribute to be what we get on the backend server
            //Note intellisense won't help out as much here
            document.querySelector("#pokemonImage").setAttribute("src", pokemon.sprites.front_default);

            //Looks at the div with an id of result and specifically grabs all the caption element inside of that div
            //Since it is List, forEach() method will go through each of the caption element
            //And our arrow function will go ahead and delete each of the element
            document.querySelectorAll("#result caption").forEach((element) => element.remove());

            let caption = document.createElement("caption");
            caption.innerHTML = pokemon.name;

            document.querySelector("#result").appendChild(caption);
        }
    }

    //This sets up our HTTPRequest on what backend server to choose, what http verb it should be, async or not
    xhr.open("GET", `https://pokeapi.co/api/v2/pokemon/${pokemonName}`, true);

    //Sends the request
    xhr.send();
}

function getPokemonFetch() {
    let pokemonName = document.querySelector("#pokemonName").value;

    //Fetch api gives out a promise
    //A promise will either execute successfully or a failure and that's it
    fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonName}`)
        //Then is the operation you want to do after a promise was successful (by default can be configure to also if promise was unsuccessful)
        //JSON is a useful object in JS that can parse JavaScript objects into JSON objects or vice versa
        .then(result => result.json())
        .then(pokemon => {
            document.querySelector("#pokemonImage").setAttribute("src", pokemon.sprites.front_default);
            document.querySelectorAll("#result caption").forEach((element) => element.remove());
            let caption = document.createElement("caption");
            caption.innerHTML = pokemon.name;
            document.querySelector("#result").appendChild(caption);
        });
}