let btn = document.getElementById("createRandom")

function createParagraph() {
    let randNum = Math.floor(Math.random() * 30) + 1;
    let newP = document.createElement("p");
    let pToInsert = document.createTextNode("Hello this paragraph is the Nº" + randNum);
    newP.appendChild(pToInsert);
    document.body.appendChild(newP);
    alert(randNum)
}

btn.addEventListener("click", function() {
    createParagraph()
})