function GetAJAXPokemon() 
{
    //Object that will send/receive from our pokemon api
    let xhr = new XMLHttpRequest();

    //Object that will hold the information we will receive from the api
    let pokemon = {};

    //Navigate the dom and find that element and get its value
    let pokemon2Find = document.querySelector("#pokemonName").value;

    /*
        onreadystatechange describes the current state of your request since it has to go through a couple loops
        0 - uninitialized
        1 - loading (server connection established)
        2 - loaded (request received and response has been sent)
        3 - interactive (response is being processed)
        4 - complete
    */
    xhr.onreadystatechange = function () 
    {
        //if condition checking once response is received and successful
        if (this.readyState == 4 && this.status > 199 && this.status < 300) 
        {
            //api gives json so we need to parse it
            pokemon = JSON.parse(xhr.responseText);
            
            //This will change the src attribute of the img tag to have the source of our pokemon
            document.querySelector(".foundPokemon img").setAttribute("src", pokemon.sprites.front_default);
            
            //Sloppy way to remove previous caption
            document.querySelectorAll(".foundPokemon caption").forEach((element) => element.remove());

            //We create a caption element
            let caption = document.createElement("caption");
            
            //We got the name of the pokemon
            let pokemonName = document.createTextNode(pokemon.forms[0].name);

            //we append the caption element to have the pokemon name
            //<caption> pokemonName </caption>
            caption.appendChild(pokemonName);

            //We select the image and append the caption element to it
            document.querySelector(".foundPokemon").appendChild(caption);
            //Sets the input back to not having anything
            document.querySelector("#pokemonName").value = "";
        }
    }

    //how XMLHTTPRequest assembly the http request
    //first param is the httpverb, second param is the endpoint of the url, third param if you want to execute it async
    xhr.open("GET", `https://pokeapi.co/api/v2/pokemon/${pokemon2Find}`, true);

    //Sends the request
    xhr.send();
}

function GetFetchPokemon()
{
    let pokemon2Find = document.querySelector("#pokemonName2").value;

    fetch(`https://pokeapi.co/api/v2/pokemon/${pokemon2Find}`)
        .then(result => result.json())
        .then(pokemon => 
        {
            //This will change the src attribute of the img tag to have the source of our pokemon
            document.querySelector(".foundPokemon img").setAttribute("src", pokemon.sprites.front_default);
            
            //Sloppy way to remove previous caption
            document.querySelectorAll(".foundPokemon caption").forEach((element) => element.remove());

            //We create a caption element
            let caption = document.createElement("caption");
            
            //We got the name of the pokemon
            let pokemonName = document.createTextNode(pokemon.forms[0].name);

            //we append the caption element to have the pokemon name
            //<caption> pokemonName </caption>
            caption.appendChild(pokemonName);

            //We select the image and append the caption element to it
            document.querySelector(".foundPokemon").appendChild(caption);
            //Sets the input back to not having anything
            document.querySelector("#pokemonName").value = "";
        })
}