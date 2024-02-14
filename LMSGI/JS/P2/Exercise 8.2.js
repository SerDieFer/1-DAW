
// ADDS A LI IN THE UL LIST
function elementAdd(){
    // SELECTS THE UL IN THE HTML AND ADDS IT TO A VARIABLE
    let ulList = document.getElementById("list");

    // CREATES A NEW LI WHICH WILL HAVE A SELECTED TEXT BY USER INPUT AND INSERTS IT INTO THE UL LIST
    let newLi = document.createElement("Li")
    let userText = prompt('Add text to this list')

    // CHECKS IF USER INPUT IS CANCELLED OR EMPTY
    if (userText !== null && userText.trim() !== "") 
    {
        let textToAdd = document.createTextNode(userText);
        newLi.appendChild(textToAdd);
        ulList.appendChild(newLi);
    } 
    else 
    {
        alert("User has entered nothing or canceled.");
    }
}

// DELETES THE LI IN THE UL LIST
function elementDelete(){
    // SELECTS THE UL IN THE HTML AND ADDS IT TO A VARIABLE
    let ulList = document.getElementById("list")
    let lastLiElement = document.getElementById("list").lastChild

    // CHECKS IF UL LIST HAS CHILD ELEMENTS
    if(ulList.hasChildNodes())
    {
        // DELETES THE LAST LI ADDED INTO UL LIST
        ulList.removeChild(lastLiElement)
    }
    else
    {
        alert('There are not elements added to the list, add something before trying to delete');
    }
}