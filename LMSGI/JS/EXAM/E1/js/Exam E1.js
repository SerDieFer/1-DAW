let elementCounterbtn = document.getElementById("elementCounter")
let addTitleH1btn = document.getElementById("addTitleH1")
let changeHrefbtn = document.getElementById("changeHref")
let paragraph = document.getElementById("paragraphCountTxt")
let link1 = document.getElementsByTagName('a')[0];
let link2 = document.getElementsByTagName('a')[1];

function changeLinksRef() {

    let changed = false;
    if(!changed)
    {
        link1.href = "https://es.wikipedia.org"
        link1.innerHTML = "Wikipedia"
        link2.href = "https://www.google.es"
        link2.innerHTML = "Google"
        changed = true;
    }
    else
    {
        link1.href = "https://www.google.es"
        link1.innerHTML = "Google"
        link2.href = "https://es.wikipedia.org"
        link2.innerHTML = "Wikipedia"
    }
}

function changeTxt() {

    let paragraphTxt = document.getElementsByID('paragraphCountTxt');
    paragraphTxt.innerText = "";
}

function countButtons() {
    let buttons = document.getElementsByTagName("button")
    let bCounter = 0;
    for(let i = 0; i < buttons.length;i++)
    {
        bCounter++;
    }
    return bCounter
}

function countLinks() {
    let links = document.getElementsByTagName("a")
    let lCounter = 0;
    for(let i = 0; i < links.length;i++)
    {
        lCounter++;
    }
    return lCounter
}

function countTitles() {
    let h1 = document.getElementsByTagName("h1")
    let h1Counter = 0;
    for(let i = 0; i < h1.length;i++)
    {
        h1Counter++;
    }
    return h1Counter
}

function totalCount() {
    let btns = countButtons()
    let links = countLinks()
    let h1 = countTitles()

    paragraph.innerHTML = "The num of buttons are: " + btns + "<br/>The num of links are: " + links + "<br/> The num of h1 are: " + h1
}

function createTitle() {
     let newH1 = document.createElement("h1");
     let H1prompt = prompt("Insert selected text: ")
     let H1toInsert = document.createTextNode(H1prompt);
     newH1.appendChild(H1toInsert);
     document.body.appendChild(newH1);
}

elementCounterbtn.addEventListener("click", function() {
    totalCount()
})

addTitleH1btn.addEventListener("click", function() {
    createTitle()
})

changeHrefbtn.addEventListener("click", function() {
    changeLinksRef() 
})